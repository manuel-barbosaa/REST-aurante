import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConsultarEmentasComponent } from './consultar-ementa.component';

describe('ConsultarEmentasComponent', () => {
  let component: ConsultarEmentasComponent;
  let fixture: ComponentFixture<ConsultarEmentasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConsultarEmentasComponent], // Atualizado para standalone
    }).compileComponents();

    fixture = TestBed.createComponent(ConsultarEmentasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
