import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ementa } from '../Models/ementa';

@Injectable({
  providedIn: 'root'
})
export class EmentaService {

  apiURL = "http://localhost:8080/api/ementas";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  obterEmentaDisponivel(): Observable<Ementa[]> {
    return this.http.get<Ementa[]>(this.apiURL);
  }
}
