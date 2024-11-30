import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ementa } from '../Models/ementa';

@Injectable({
  providedIn: 'root'
})
export class EmentaService {

  private theServerURL = 'http://localhost:8080/api';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private webApiClient: HttpClient) { }

  // Método para obter a ementa de uma refeição, com base no ID da refeição
  getEmentaByRefeicaoId(refeicaoId: number): Observable<Ementa> {
    return this.webApiClient.get<Ementa>(`${this.theServerURL}/ementa/${refeicaoId}`);
  }
}
