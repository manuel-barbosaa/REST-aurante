import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivatePratoComponent } from './activate-prato.component';

describe('ActivatePratoComponent', () => {
  let component: ActivatePratoComponent;
  let fixture: ComponentFixture<ActivatePratoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActivatePratoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActivatePratoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
