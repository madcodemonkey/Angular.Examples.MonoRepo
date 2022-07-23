import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactiveFormsValidationSimple1Component } from './reactive-forms-validation-simple1.component';

describe('ReactiveFormsValidationSimple1Component', () => {
  let component: ReactiveFormsValidationSimple1Component;
  let fixture: ComponentFixture<ReactiveFormsValidationSimple1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReactiveFormsValidationSimple1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReactiveFormsValidationSimple1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
