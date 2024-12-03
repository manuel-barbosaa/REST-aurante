import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConsultarEncomendasComponent } from './consultar-encomenda.component';

describe('EncomendasComponent', () => {
  let component: ConsultarEncomendasComponent;
  let fixture: ComponentFixture<ConsultarEncomendasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultarEncomendasComponent ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(ConsultarEncomendasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
