import { Routes } from '@angular/router';
import { ConsultarEmentasComponent } from './cliente/consultar-ementa/consultar-ementa.component';
import { EncomendaDetailComponent } from './cliente/encomenda-details/encomenda-detail.component';
import { ConsultarEncomendasComponent } from './cliente/consultar-encomenda/consultar-encomenda.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },  // Rota para a página inicial
  { path: 'ementas', component: ConsultarEmentasComponent },
  { path: 'encomendas', component: ConsultarEncomendasComponent, children: [
      { path: 'encomenda/:id', component: EncomendaDetailComponent },
    ] },
];
