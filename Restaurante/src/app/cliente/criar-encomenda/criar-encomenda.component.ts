import {Component, Inject, OnInit, PLATFORM_ID} from '@angular/core';
import {EncomendaService} from '../../services/encomenda.service';
import {Encomenda} from '../../Models/encomenda';
import {isPlatformBrowser, NgClass, NgForOf, NgIf} from '@angular/common';
import {EmentaService} from '../../services/ementa.service';
import {Ementa} from '../../Models/ementa';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-criar-encomenda',
  imports: [
    NgForOf,
    FormsModule,
    NgClass,
    NgIf
  ],
  templateUrl: './criar-encomenda.component.html',
  standalone: true,
  styleUrl: './criar-encomenda.component.css'
})
export class CriarEncomendaComponent implements OnInit{
  ementas: Ementa[] = [];
  constructor(private ementaService: EmentaService, private encomendaService: EncomendaService) {}

  selected: any;
  selectedEmenta: Ementa | null = null;
  alertMessage: string = '';
  alertClass: string = '';


  update(e: any){
    this.selected = e.target
  }

  ngOnInit(): void {
    this.ementaService.obterEmentaDisponivel().subscribe({
      next: (resposta: Ementa[]) => {
        this.ementas = resposta || [];
      },
      error: (erro) => {
        console.error('Erro ao obter encomendas:', erro);
        this.ementas = [];
      }
    });
  }

  showAlert(message: string, type: 'success' | 'error'): void {
    this.alertMessage = message;
    this.alertClass = type;
    setTimeout(() => {
      this.alertMessage = ''; // Clear the alert after 5 seconds
    }, 5000);
  }

  encomendar(): void {
    const clienteNif = localStorage.getItem('clienteNif');

    if (!clienteNif) {
      this.showAlert('Cliente NIF não encontrado.', 'error');
      return;
    }

    console.log(this.selectedEmenta)

    if (!this.selectedEmenta || !this.selectedEmenta.id) {
      this.showAlert('Por favor, selecione um prato.', 'error');
      return;
    }

    this.encomendaService.criarEncomenda(this.selectedEmenta.id, clienteNif).subscribe({
      next: () => {
        this.showAlert('Encomenda efetuada com sucesso!', 'success');
      },
      error: (erro) => {
        const errorMessage = erro?.error?.error || 'Erro ao criar encomenda. Tente novamente.';
        this.showAlert(errorMessage, 'error');
      }
    });
  }

  protected localStorage = localStorage;
}
