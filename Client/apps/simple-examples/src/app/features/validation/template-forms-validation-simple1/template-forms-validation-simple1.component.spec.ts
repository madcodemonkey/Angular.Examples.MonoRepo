import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateFormsValidationSimple1Component } from './template-forms-validation-simple1.component';

describe('TemplateFormsValidationSimple1Component', () => {
  let component: TemplateFormsValidationSimple1Component;
  let fixture: ComponentFixture<TemplateFormsValidationSimple1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TemplateFormsValidationSimple1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateFormsValidationSimple1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
