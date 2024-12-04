import { Component, OnInit } from '@angular/core';
import { PratoService } from '../../services/prato.service';
import { FormsModule } from '@angular/forms';
import { NgClass, NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-prato-creation',
  standalone: true,
  imports: [FormsModule, NgClass, NgIf],
  templateUrl: './prato-creation.component.html',
  styleUrl: './prato-creation.component.css',
})
export class PratoCreationComponent implements OnInit {
 
    nome: string= '';
    tipoPrato: string= '';
    ingredientes: string= '';
    receita: string= '';
    isAtivo: string = "";
  

  alertMessage: string = '';
  alertClass: string = '';

  constructor(private pratoService: PratoService) {}

  ngOnInit(): void {

  }

  showAlert(message: string, type: 'success' | 'error'): void {
    this.alertMessage = message;
    this.alertClass = type;
    setTimeout(() => {
      this.alertMessage = '';
    }, 5000);
  }

  criarPrato(): void {
    
    let newPrato = {
      nome: this.nome,
      isAtivo :  this.isAtivo == "true",
      tipoPrato : parseInt (this.tipoPrato),
      ingredientes : [parseInt(this.ingredientes)],
      receita :this.receita
      
    }
    console.log(newPrato);
    this.pratoService.createPrato(newPrato).subscribe();
  }
}
