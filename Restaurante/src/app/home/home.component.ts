import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';


@Component({
  selector: 'app-home',
  imports: [RouterOutlet, RouterLink, RouterLinkActive, NgIf],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  mode: string = 'Modo Cliente'; // Default mode
  isClienteMode: boolean = true; // Default to Cliente mode

  toggleMode(event: Event): void {
    const checkbox = event.target as HTMLInputElement;
    this.isClienteMode = !checkbox.checked; // If checked, switch to Chef mode
    this.mode = this.isClienteMode ? 'Modo Cliente' : 'Modo Chef';
  }
}
