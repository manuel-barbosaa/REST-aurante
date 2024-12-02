import { Router } from '@angular/router';
import { NgFor } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgFor, RouterOutlet, RouterLink],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  mode: string = 'Modo Cliente';  // Inicializa o modo como 'Modo Cliente'

  // Funcionalidades do cliente
  usCliente = [
    'Carregar a minha conta cliente.',
    'Consultar a ementa disponível.',
    'Encomendar um prato existente na ementa.',
    'Listar todas as encomendas realizadas.',
  ];

  // Funcionalidades do chef
  usChef = [
    'Configurar um prato definindo código único, nome, tipo, ingredientes e receita.',
    'Ativar/Inativar um prato pelo seu código único.',
    'Criar uma refeição especificando prato, data, tipo e quantidade.',
    'Remover uma refeição futura com data posterior à atual.',
  ];

  // Método para alternar o modo
  toggleMode(event: any) {
    this.mode = event.target.checked ? 'Modo Chef' : 'Modo Cliente';
  }

  // Função para voltar à página inicial
  goBack() {
    window.history.back();  // Volta à página anterior
  }
}
