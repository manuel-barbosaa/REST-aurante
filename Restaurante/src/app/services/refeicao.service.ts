import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Refeicao } from '../Models/refeicao';


@Injectable({
  providedIn: 'root'
})
export class RefeicaoService {
  private serverURL = 'http://localhost:5230/api/Refeicao/';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private webApiClient: HttpClient) {}

  getAllRefeicoes(): Observable<Refeicao[]> {
    return this.webApiClient.get<Refeicao[]>(this.serverURL + "all");
  }

  createRefeicao(newRefeicao: any): Observable<any> {
    return this.webApiClient.post(this.serverURL, newRefeicao, this.httpOptions);
  }

  deleteRefeicao(id: number): Observable<any> {
    return this.webApiClient.delete(this.serverURL + id + "/remover");
  }
  
}