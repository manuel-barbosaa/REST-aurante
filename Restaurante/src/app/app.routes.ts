import { Routes } from '@angular/router';
import { ConsultarEmentasComponent } from './cliente/consultar-ementa/consultar-ementa.component';
import { EncomendaDetailComponent } from './cliente/encomenda-details/encomenda-detail.component';
import { ConsultarEncomendasComponent } from './cliente/consultar-encomenda/consultar-encomenda.component';

export const routes: Routes = [
  { path: '', redirectTo: '/ementas', pathMatch: 'full' },
  { path: 'ementas', component: ConsultarEmentasComponent },
  { path: 'encomendas', component: ConsultarEncomendasComponent, children: [
      { path: 'encomenda/:id', component: EncomendaDetailComponent },
    ] },
];
