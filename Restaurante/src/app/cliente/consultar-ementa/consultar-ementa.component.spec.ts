import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EmentaComponent } from './consultar-ementa.component';

describe('EmentaComponent', () => {
  let component: EmentaComponent;
  let fixture: ComponentFixture<EmentaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmentaComponent ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(EmentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
