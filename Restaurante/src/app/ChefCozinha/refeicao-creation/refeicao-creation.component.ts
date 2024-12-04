import { Component } from '@angular/core';
import { RefeicaoService } from '../../services/refeicao.service';
import { NgClass, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';



@Component({
  selector: 'app-refeicao-creation',
  imports: [FormsModule, NgClass, NgIf],
  templateUrl: './refeicao-creation.component.html',
  styleUrl: './refeicao-creation.component.css'
})
export class RefeicaoCreationComponent {

  pratoId: string="";
  tipoRefeicaoId: string="";
  quantidade: string="";
  data: string="";

  alertMessage: string = '';
  alertClass: string = '';

  constructor(private srv: RefeicaoService) {}

  createRefeicao(): void {

    let newRefeicao = {
      "prato": parseInt(this.pratoId),
      "tipoRefeicao": parseInt(this.tipoRefeicaoId),
      "quantidade": parseInt(this.quantidade),
      "data": this.data
    }
    this.srv.createRefeicao(newRefeicao).subscribe();
  }
}
