import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service'; 
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  imports: [ FormsModule, CommonModule, FormsModule],
  selector: 'app-carregar-conta-cliente',
  templateUrl: './carregar-conta-cliente.component.html',
  standalone: true,
  styleUrls: ['./carregar-conta-cliente.component.css']
})
export class CarregarContaClienteComponent implements OnInit {
  nif : string ="";
  quantia: number = 0;  // Valor a ser adicionado ao saldo

  cliente: any;  // Dados do cliente após consulta

  constructor(private clienteService: ClienteService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const clienteNif = localStorage.getItem('clienteNif') || '';

    if (!clienteNif) {
      return;
    }
      this.clienteService.getClienteByNIF(clienteNif).subscribe(resp => {
        this.nif = clienteNif;
        this.cliente = resp;
      });
  }

  carregarConta(): void {
    if (this.quantia > 0) {
      this.clienteService.depositSaldo(this.nif, this.quantia).subscribe(
        (response) => {
          alert('Saldo carregado com sucesso!');
          this.cliente.saldo += this.quantia;  // Atualiza o saldo local
        },
        (error) => {
          alert('Erro ao carregar a conta. Tente novamente.');
        }
      );
    } else {
      alert('Digite um valor positivo para o depósito.');
    }
  }

  protected readonly localStorage = localStorage;
}
