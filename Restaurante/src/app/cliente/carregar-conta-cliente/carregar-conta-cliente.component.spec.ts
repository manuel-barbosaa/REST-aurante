import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarregarContaClienteComponent } from './carregar-conta-cliente.component';

describe('CarregarContaClienteComponent', () => {
  let component: CarregarContaClienteComponent;
  let fixture: ComponentFixture<CarregarContaClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarregarContaClienteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarregarContaClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
