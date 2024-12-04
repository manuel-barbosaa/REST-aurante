import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFutureRefeicaoComponent } from './delete-future-refeicao.component';

describe('DeleteFutureRefeicaoComponent', () => {
  let component: DeleteFutureRefeicaoComponent;
  let fixture: ComponentFixture<DeleteFutureRefeicaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteFutureRefeicaoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteFutureRefeicaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
