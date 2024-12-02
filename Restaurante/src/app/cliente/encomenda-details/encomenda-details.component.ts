import { Component, OnInit } from '@angular/core';
import { EncomendaService } from '../../services/encomenda.service';
import { Encomenda } from '../../Models/encomenda';
import { ActivatedRoute } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-encomenda-detail',
  standalone: true,
  imports: [NgIf],
  templateUrl: './encomenda-details.component.html',
  styleUrls: ['./encomenda-details.component.css']
})
export class EncomendaDetailComponent implements OnInit {

  encomenda?: Encomenda;

  constructor(
    private encomendaService: EncomendaService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const encomendaId = params['id'];
      this.encomendaService.getEncomendaById(encomendaId).subscribe(resp => this.encomenda = resp);
    });
  }
}
