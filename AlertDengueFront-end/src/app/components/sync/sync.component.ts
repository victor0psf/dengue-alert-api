import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { DengueAlert } from '../../models/dengue-alert.model';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-sync',
  templateUrl: './sync.component.html',
  styleUrls: ['./sync.component.css'],
  imports: [CommonModule, RouterModule],
})
export class SyncComponent {
  loading = false;
  message = '';
  count = 0;
  error = '';
  alerts: DengueAlert[] = [];

  constructor(private readonly api: ApiService) {}

  async sync() {
    this.loading = true;
    this.message = '';
    this.error = '';
    this.alerts = [];

    try {
      // syncAlerts agora retorna diretamente um array de DengueAlert
      const res = await lastValueFrom(this.api.getAllAlerts());
      console.log('sync result:', res);

      this.alerts = res || [];
      this.message = `Sincronização concluída com ${this.alerts.length} alertas`;
      this.count = this.alerts.length;
    } catch (err: any) {
      console.error(err);
      this.error = err?.message || 'Falha ao sincronizar';
    } finally {
      this.loading = false;
    }
  }
}
