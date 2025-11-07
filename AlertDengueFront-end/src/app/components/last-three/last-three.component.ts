import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DengueAlert } from '../../models/dengue-alert.model';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-last-three',
  templateUrl: './last-three.component.html',
  styleUrls: ['./last-three.component.css'],
  imports: [CommonModule, RouterModule],
})
export class LastThreeComponent implements OnInit {
  loading = false;
  alerts: DengueAlert[] = [];
  lastThree: DengueAlert[] = [];
  error = '';
  message = '';
  Math = Math;

  // flag para impedir múltiplas sincronizações
  private alreadySynced = false;

  constructor(private readonly api: ApiService) {}

  ngOnInit(): void {
    this.load();
  }

  /** Carrega todos os alertas e calcula as últimas 3 semanas */
  load(): void {
    this.loading = true;
    this.error = '';
    this.message = '';

    this.api.getAllAlerts().subscribe({
      next: (arr) => {
        this.alerts = arr || [];
        this.processLastThree();
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Falha ao carregar alertas';
        this.loading = false;
      },
    });
  }

  /** Sincroniza os alertas com o backend e atualiza a lista */
  sync(): void {
    // impede múltiplas chamadas
    if (this.alreadySynced) {
      this.message = 'Já fui sincronizado';
      setTimeout(() => (this.message = ''), 3000); // some depois de 3s
      return; // MUITO IMPORTANTE: não chamar a API novamente
    }

    this.loading = true;
    this.error = '';
    this.message = '';

    this.api.syncAlerts().subscribe({
      next: (res) => {
        this.alerts = res || [];
        this.processLastThree();
        this.message = `Sincronização concluída com ${this.alerts.length} alertas`;
        this.alreadySynced = true; // marca que já sincronizou
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Falha ao sincronizar alertas';
        this.loading = false;
      },
    });
  }

  /** Processa as últimas 3 semanas a partir do array de alertas */
  private processLastThree(): void {
    const normalized = this.alerts.map((a) => {
      const weekNum = a.SE ?? 0;
      let year = a.epidemiologicalYear ?? 0;
      let week = 0;

      if (!year && weekNum > 1000) {
        year = Math.floor(weekNum / 100);
        week = weekNum % 100;
      } else {
        week = weekNum;
      }

      return { ...a, _year: year, _week: week };
    });

    normalized.sort((x, y) =>
      x._year !== y._year ? y._year - x._year : y._week - x._week
    );

    const picked: DengueAlert[] = [];
    const seen = new Set<string>();
    for (const n of normalized) {
      const key = `${n._year}-${n._week}`;
      if (!seen.has(key)) {
        seen.add(key);
        picked.push(n);
        if (picked.length === 3) break;
      }
    }

    this.lastThree = picked;
  }
}
