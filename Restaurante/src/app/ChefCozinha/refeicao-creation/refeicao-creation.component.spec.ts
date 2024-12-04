import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefeicaoCreationComponent } from './refeicao-creation.component';

describe('RefeicaoCreationComponent', () => {
  let component: RefeicaoCreationComponent;
  let fixture: ComponentFixture<RefeicaoCreationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RefeicaoCreationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RefeicaoCreationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
