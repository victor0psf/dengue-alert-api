import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DengueAlert } from '../models/dengue-alert.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  // ajuste aqui se a API estiver em outro host/porta (no Docker, porta 8080)
  private readonly baseUrl =
    (window as any).__env?.API_BASE_URL || 'http://localhost:8080/api/dengue';

  constructor(private readonly http: HttpClient) {}

  /**
   * GET /api/dengue/get-all
   * Retorna todos os alertas diretamente como array
   */
  getAllAlerts(): Observable<DengueAlert[]> {
    return this.http.get<DengueAlert[]>(`${this.baseUrl}/get-all`);
  }

  /**
   * POST /api/dengue/sync
   * Sincroniza alertas e retorna os alertas sincronizados
   */
  syncAlerts(): Observable<DengueAlert[]> {
    return this.http.post<DengueAlert[]>(
      `${this.baseUrl}/sync`,
      {}, // corpo vazio
      { responseType: 'json' } // garante JSON
    );
  }

  /**
   * GET /api/dengue/{week}
   * Retorna alerta por semana específica
   */
  getAlertByWeek(week: number): Observable<DengueAlert> {
    return this.http.get<DengueAlert>(`${this.baseUrl}/${week}`);
  }
}
