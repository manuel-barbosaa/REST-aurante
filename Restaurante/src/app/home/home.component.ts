import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgIf } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-home',
  imports: [RouterOutlet, RouterLink, RouterLinkActive, NgIf,],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  mode: string;
  isClienteMode: boolean; 

  constructor(private router: Router) {

    const savedMode = localStorage.getItem('mode');
    this.isClienteMode = savedMode === 'Modo Cliente' || !savedMode; 
    this.mode = this.isClienteMode ? 'Modo Cliente' : 'Modo Chef';
  }

  toggleMode(event: Event): void {
    const checkbox = event.target as HTMLInputElement;
    this.isClienteMode = !checkbox.checked;
    this.mode = this.isClienteMode ? 'Modo Cliente' : 'Modo Chef';
    localStorage.setItem('mode', this.mode);

    if (this.isClienteMode) {
      this.router.navigate(['/ementas']);
    } else {
      this.router.navigate(['/criar-prato']);
    }
  }
}
