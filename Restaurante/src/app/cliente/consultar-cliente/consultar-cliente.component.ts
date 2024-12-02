import { Component, OnInit } from '@angular/core';
import {  NgFor } from '@angular/common';
import { ClienteService, Cliente } from '../../services/cliente.service'; 
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';



@Component({
  imports:[RouterModule, NgFor, CommonModule, FormsModule],
  selector: 'app-consultar-cliente',
  templateUrl: './consultar-cliente.component.html',
  styleUrls: ['./consultar-cliente.component.css']
})
export class ConsultarClienteComponent implements OnInit {
reload() {
throw new Error('Method not implemented.');
}
  nif: string = '';  // NIF do cliente a ser consultado
  cliente: Cliente | undefined;

  constructor(private clienteService: ClienteService) {}

  ngOnInit(): void {}

  consultarCliente(): void {
    if (this.nif) {
      this.clienteService.getClienteByNIF(this.nif).subscribe(
        (resp) => {
          this.cliente = resp;
        },
        (error) => {
          alert('Cliente não encontrado ou erro na consulta.');
        }
      );
    }
  }
}
