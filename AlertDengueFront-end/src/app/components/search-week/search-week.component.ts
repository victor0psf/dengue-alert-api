import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DengueAlert } from '../../models/dengue-alert.model';
import { ApiService } from '../../services/api.service';

@Component({
  standalone: true,
  selector: 'app-search-week',
  templateUrl: './search-week.component.html',
  styleUrls: ['./search-week.component.css'],
  imports: [CommonModule, FormsModule, RouterModule],
})
export class SearchWeekComponent {
  week!: number;
  loading = false;
  error = '';
  result?: DengueAlert;

  constructor(private readonly api: ApiService) {}

  search() {
    // Validação
    if (!this.week || this.week <= 0) {
      this.error = 'Informe uma Semana válida.';
      this.result = undefined;
      return;
    }

    this.loading = true;
    this.error = '';
    this.result = undefined;

    this.api.getAlertByWeek(this.week).subscribe({
      next: (res) => {
        this.result = res;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Nenhum dado encontrado para esta semana.';
        this.loading = false;
      },
    });
  }
}
