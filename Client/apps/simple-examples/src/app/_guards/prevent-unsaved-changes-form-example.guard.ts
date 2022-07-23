import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { TemplateFormsValidationSimple1Component } from '../features/validation/template-forms-validation-simple1/template-forms-validation-simple1.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesFormExampleGuard implements CanDeactivate<unknown> {

  canDeactivate(component: TemplateFormsValidationSimple1Component): boolean  {
    if (component.editForm.dirty){
      return confirm('Are you sure you want to continue?  Any unsaved changes will be lost!')
    }

    return true;
  }

}
