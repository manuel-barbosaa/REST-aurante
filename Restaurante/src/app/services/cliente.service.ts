import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Cliente {
  nome: string;
  nif: string;
  email: string;
  saldo: number;
}

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private apiURL = 'http://localhost:8080/api/clientes'; // URL da API

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(private http: HttpClient) {}

  // Método para buscar todas as informações do cliente pelo NIF
  getClienteByNIF(nif: string): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.apiURL}/${nif}`);
  }

  // Método para carregar saldo (depósito de quantia)
  depositSaldo(nif: string, quantia: number): Observable<any> {
    const body = { quantia }; // Envia a quantia como JSON
    return this.http.patch(`${this.apiURL}/${nif}/deposit`, body, this.httpOptions);
  }
}
