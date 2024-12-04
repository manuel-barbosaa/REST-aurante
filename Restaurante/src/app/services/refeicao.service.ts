import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RefeicaoService {
  private serverURL = 'http://localhost:5230/api/Refeicao';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private webApiClient: HttpClient) {}

  createRefeicao(newRefeicao: any): Observable<any> {
    console.log(newRefeicao);
    return this.webApiClient.post(this.serverURL, newRefeicao, this.httpOptions);
  }
  
}