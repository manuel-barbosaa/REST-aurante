import { Component } from '@angular/core';
import { Refeicao } from '../../Models/refeicao';
import { RefeicaoService } from '../../services/refeicao.service';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-delete-future-refeicao',
  imports: [NgIf, NgFor],
  templateUrl: './delete-future-refeicao.component.html',
  styleUrls: ['./delete-future-refeicao.component.css']
})
export class DeleteFutureRefeicaoComponent {

  allRefeicoes: Refeicao[] | undefined;

  constructor(private srv: RefeicaoService) {}

  ngOnInit(): void {
    this.srv.getAllRefeicoes().subscribe(response => this.allRefeicoes = response);
  }

  deleteRefeicao(id: number): void {
    // Display confirm dialog to ask if the user really wants to delete
    const confirmed = confirm('Tem certeza que deseja apagar esta refeição?');
    
    if (confirmed) {
      // Perform the delete action if confirmed
      this.srv.deleteRefeicao(id).subscribe(
        () => {
          // After successful deletion, refresh the list
          this.srv.getAllRefeicoes().subscribe(response => this.allRefeicoes = response);
        },
        (error) => {
          // If there's an error, display an alert message
          alert('A refeição selecionada não é futura.');
        }
      );
    }
  }
}
