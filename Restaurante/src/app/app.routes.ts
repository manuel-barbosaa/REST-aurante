import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ConsultarEmentasComponent } from './cliente/consultar-ementa/consultar-ementa.component';
import { ConsultarEncomendasComponent } from './cliente/consultar-encomenda/consultar-encomenda.component';
import { ConsultarClienteComponent } from './cliente/consultar-cliente/consultar-cliente.component';
import { CarregarContaClienteComponent } from './cliente/carregar-conta-cliente/carregar-conta-cliente.component';
import { EncomendaDetailComponent } from './cliente/encomenda-details/encomenda-details.component';
import {CriarEncomendaComponent} from './cliente/criar-encomenda/criar-encomenda.component';
import { PratoCreationComponent } from './ChefCozinha/prato-creation/prato-creation.component';
import { RefeicaoCreationComponent } from './ChefCozinha/refeicao-creation/refeicao-creation.component';
import { DeleteFutureRefeicaoComponent } from './ChefCozinha/delete-future-refeicao/delete-future-refeicao.component';

export const routes: Routes = [

  { path: '', component: HomeComponent },  // Rota para a página inicial
  { path: 'ementas', component: ConsultarEmentasComponent },
  { path: 'consultar-cliente', component: ConsultarClienteComponent },
  { path: 'carregar-conta', component: CarregarContaClienteComponent },
  { path: 'encomendas', component: ConsultarEncomendasComponent, children: [
      { path: 'encomenda/:id', component: EncomendaDetailComponent },
    ] },
  { path: 'criar-encomenda', component: CriarEncomendaComponent},
  { path: 'criar-prato', component: PratoCreationComponent },
  { path: 'criar-refeicao', component: RefeicaoCreationComponent},
  { path: 'delete-refeicao', component: DeleteFutureRefeicaoComponent}
];
