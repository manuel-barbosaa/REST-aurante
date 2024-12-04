import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  mode: string = 'Modo Cliente';
  
  updateClass (){
  }

  toggleMode(event: any) {
    this.mode = event.target.checked ? 'Modo Chef' : 'Modo Cliente';
  }
}
