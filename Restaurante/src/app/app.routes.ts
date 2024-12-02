import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ConsultarEmentasComponent } from './cliente/consultar-ementa/consultar-ementa.component';
import { ConsultarEncomendasComponent } from './cliente/consultar-encomenda/consultar-encomenda.component';
import { ConsultarClienteComponent } from './cliente/consultar-cliente/consultar-cliente.component';
import { CarregarContaClienteComponent } from './cliente/carregar-conta-cliente/carregar-conta-cliente.component';
import { EncomendaDetailComponent } from './cliente/encomenda-details/encomenda-details.component';

export const routes: Routes = [
 
  { path: '', component: HomeComponent },  // Rota para a página inicial
  { path: 'ementas', component: ConsultarEmentasComponent },
  { path: 'consultar-cliente', component: ConsultarClienteComponent },
  { path: 'carregar-conta/:nif', component: CarregarContaClienteComponent },
  { path: '', redirectTo: '/consultar-cliente', pathMatch: 'full' },
  { path: 'encomendas', component: ConsultarEncomendasComponent, children: [
      { path: 'encomenda/:id', component: EncomendaDetailComponent },
    ] },
];
