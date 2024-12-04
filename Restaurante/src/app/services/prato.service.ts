import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Prato } from '../Models/prato';

@Injectable({
  providedIn: 'root',
})
export class PratoService {
  private serverURL = 'http://localhost:5230/api/prato'; // URL base da API

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  // Método para criar um prato
  createPrato(newPrato: any): Observable<any> {
    return this.http.post(this.serverURL, newPrato, this.httpOptions);
  }
}
