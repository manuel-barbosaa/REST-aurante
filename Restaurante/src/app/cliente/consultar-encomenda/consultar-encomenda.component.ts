import { Component, OnInit } from '@angular/core';
import { EncomendaService } from '../../services/encomenda.service'; // Adapte com seu serviço
import { Encomenda } from '../../Models/encomenda'; // Adapte com seu modelo
import { NgFor } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-consultar-encomenda',
  standalone: true,
  imports: [NgFor, RouterOutlet, RouterLink],
  templateUrl: './consultar-encomenda.component.html',
  styleUrls: ['./consultar-encomenda.component.css']
})
export class ConsultarEncomendasComponent implements OnInit {
  encomendas: Encomenda[] | undefined;

  constructor(private encomendaService: EncomendaService) {}

  ngOnInit(): void {
    this.encomendaService.obterEncomendasDoCliente().subscribe((resposta) => {
      this.encomendas = resposta;
    });
  }

  reload(): void {
    console.log('Reloading');
    this.encomendaService.obterEncomendasDoCliente().subscribe((resposta) => {
      this.encomendas = resposta;
    });
  }
}
