import { RouterLink, Routes } from '@angular/router';
import { ConsultarEmentasComponent } from './cliente/consultar-ementa/consultar-ementa.component';
import { ConsultarEncomendasComponent } from './cliente/consultar-encomenda/consultar-encomenda.component';
import { ConsultarClienteComponent } from './cliente/consultar-cliente/consultar-cliente.component';
import { CarregarContaClienteComponent } from './cliente/carregar-conta-cliente/carregar-conta-cliente.component';
import {CriarEncomendaComponent} from './cliente/criar-encomenda/criar-encomenda.component';
import { PratoCreationComponent } from './ChefCozinha/prato-creation/prato-creation.component';
import { RefeicaoCreationComponent } from './ChefCozinha/refeicao-creation/refeicao-creation.component';
import { DeleteFutureRefeicaoComponent } from './ChefCozinha/delete-future-refeicao/delete-future-refeicao.component';
import { HomeComponent } from './home/home.component';
import { ActivatePratoComponent } from './ChefCozinha/activate-prato/activate-prato.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      { path: '', redirectTo: 'consultar-cliente', pathMatch: 'full' }, // Default child route
      { path: 'ementas', component: ConsultarEmentasComponent },
      { path: 'encomendas', component: ConsultarEncomendasComponent },
      { path: 'criar-encomenda', component: CriarEncomendaComponent },
      { path: 'consultar-cliente', component: ConsultarClienteComponent },
      { path: 'carregar-conta', component: CarregarContaClienteComponent },
      { path: 'criar-prato', component: PratoCreationComponent },
      { path: 'modificar-prato', component: ActivatePratoComponent},
      { path: 'criar-refeicao', component: RefeicaoCreationComponent },
      { path: 'delete-refeicao', component: DeleteFutureRefeicaoComponent },
    ],
  },
  { path: '**', redirectTo: '' }, // Redirect any unknown routes to the home
];
