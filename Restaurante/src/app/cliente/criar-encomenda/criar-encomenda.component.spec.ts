import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarEncomendaComponent } from './criar-encomenda.component';

describe('CriarEncomendaComponent', () => {
  let component: CriarEncomendaComponent;
  let fixture: ComponentFixture<CriarEncomendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriarEncomendaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriarEncomendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
