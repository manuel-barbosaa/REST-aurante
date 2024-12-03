import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Encomenda } from '../Models/encomenda';

@Injectable({
  providedIn: 'root'
})
export class EncomendaService {

  apiURL = "http://localhost:8080/api/encomendas";
  apiURL2 = "http://localhost:8080/api/encomenda";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  obterEncomendasDoCliente(): Observable<Encomenda[]> {
    return this.http.get<Encomenda[]>(this.apiURL);
  }

  getEncomendaById(id: number): Observable<Encomenda> {
    return this.http.get<Encomenda>(`${this.apiURL}/${id}`);
  }
  criarEncomenda (ementaId : string, nif: string): Observable<Encomenda>{
    return this.http.post<Encomenda>(`${this.apiURL2}/${nif}`, {'ementaId': ementaId});
  }
}
