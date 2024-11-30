import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../Models/cliente'; // Importa o model de Cliente

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  // URL da API onde os dados do cliente são acessados
  private theServerURL = "http://localhost:8080/api";  // Substitua com a URL da sua API
  // Definindo o cabeçalho Content-Type
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private webApiClient: HttpClient) { }

  // Método para obter o saldo de um cliente, com base no NIF
  getSaldoByNIF(nif: string): Observable<{ saldo: number }> {
    // Fazendo requisição GET para a API, passando o NIF do cliente
    return this.webApiClient.get<{ saldo: number }>(`${this.theServerURL}/clientes/${nif}/saldo`);
  }

  // Método para criar um novo cliente, enviando dados para a API
  createCliente(cliente: any): Observable<any> {
    return this.webApiClient.post(`${this.theServerURL}/clientes`, cliente, this.httpOptions);
  }

  // Método para atualizar o saldo de um cliente
  updateSaldo(nif: string, quantia: number): Observable<any> {
    const saldoData = { saldo: quantia };
    return this.webApiClient.patch(`${this.theServerURL}/clientes/${nif}/deposit`, saldoData, this.httpOptions);
  }
}
