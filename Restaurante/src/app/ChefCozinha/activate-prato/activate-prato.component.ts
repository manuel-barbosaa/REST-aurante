import { Component, OnInit } from '@angular/core';
import { PratoService } from '../../services/prato.service';
import { Prato } from '../../Models/prato';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-activate-prato',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './activate-prato.component.html',
  styleUrls: ['./activate-prato.component.css']
})
export class ActivatePratoComponent implements OnInit {
  allPratos: Prato[] = []; 
  selectedPrato: Prato | null = null; 

  constructor(private pratoService: PratoService) {}

  ngOnInit(): void {
    this.pratoService.getAllPratos().subscribe({
      next: (pratos) => {
        this.allPratos = pratos;
      },
      error: (err) => {
        console.error('Erro ao buscar pratos:', err);
        alert('Erro ao carregar pratos. Tente novamente mais tarde.');
      },
    });
  }

  // Método para ativar um prato
  activatePrato(pratoId: number): void {
    this.pratoService.activatePrato(pratoId).subscribe({
      next: () => {
        alert('Prato ativado com sucesso!');
        this.ngOnInit(); 
        this.selectedPrato = null; 
      },
      error: (err) => {
        console.error('Erro ao ativar prato:', err);
        alert('Erro ao ativar prato.');
      },
    });
  }

  // Método para desativar um prato
  deactivatePrato(pratoId: number): void {
    this.pratoService.deactivatePrato(pratoId).subscribe({
      next: () => {
        alert('Prato desativado com sucesso!');
        this.ngOnInit();
        this.selectedPrato = null; 
      },
      error: (err) => {
        console.error('Erro ao desativar prato:', err);
        alert('Erro ao desativar prato.');
      },
    });
  }

  // Método para selecionar um prato
  selectPrato(prato: Prato): void {
    this.selectedPrato = prato;
  }
}
