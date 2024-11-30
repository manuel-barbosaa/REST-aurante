import { Component, OnInit } from '@angular/core';
import { EmentaService } from '../../services/ementa.service'; // Adapte com seu serviço
import { Ementa } from '../../Models/ementa'; // Adapte com seu modelo
import { NgFor } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-consultar-ementa',
  standalone: true,
  imports: [NgFor, RouterOutlet, RouterLink],
  templateUrl: './consultar-ementa.component.html',
  styleUrls: ['./consultar-ementa.component.css']
})
export class ConsultarEmentasComponent implements OnInit {
  ementas: Ementa[] | undefined;

  constructor(private ementaService: EmentaService) {}

  ngOnInit(): void {
    this.ementaService.obterEmentaDisponivel().subscribe((resposta) => {
      this.ementas = resposta;
    });
  }

  reload(): void {
    console.log('Reloading');
    this.ementaService.obterEmentaDisponivel().subscribe((resposta) => {
      this.ementas = resposta;
    });
  }
}
