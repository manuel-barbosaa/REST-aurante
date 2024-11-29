import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PratoCreationComponent } from './prato-creation.component';

describe('PratoCreationComponent', () => {
  let component: PratoCreationComponent;
  let fixture: ComponentFixture<PratoCreationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PratoCreationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PratoCreationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
