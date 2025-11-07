import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DengueAlert } from '../models/dengue-alert.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  // quando estiver rodando no Docker, usar o host "api"
  private readonly baseUrl =
    (window as any).__env?.API_BASE_URL || 'http://localhost:8080/api/dengue';

  constructor(private readonly http: HttpClient) {}

  getAllAlerts(): Observable<DengueAlert[]> {
    return this.http.get<DengueAlert[]>(`${this.baseUrl}/get-all`);
  }

  syncAlerts(): Observable<DengueAlert[]> {
    return this.http.post<DengueAlert[]>(
      `${this.baseUrl}/sync`,
      {},
      { responseType: 'json' }
    );
  }

  getAlertByWeek(week: number): Observable<DengueAlert> {
    return this.http.get<DengueAlert>(`${this.baseUrl}/${week}`);
  }
}
