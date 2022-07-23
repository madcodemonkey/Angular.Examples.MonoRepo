import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DownloadFileExampleComponent } from './features/downloadfile/download-file-example.component';
import { HomeComponent } from './features/home/home.component';
import { ReactiveFormsValidationSimple1Component } from './features/validation/reactive-forms-validation-simple1/reactive-forms-validation-simple1.component';
import { TemplateFormsValidationSimple1Component } from './features/validation/template-forms-validation-simple1/template-forms-validation-simple1.component';
import { PreventUnsavedChangesFormExampleGuard } from './_guards/prevent-unsaved-changes-form-example.guard';
import { StateListResolver } from './_resolvers/state-list.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'download', component: DownloadFileExampleComponent },
  {
    path: 'validation',
    children: [
      { path: 'template-forms/simple1/:id', component: TemplateFormsValidationSimple1Component,
        resolve: {states: StateListResolver},
        canDeactivate: [PreventUnsavedChangesFormExampleGuard]
      },
      { path: 'reactive-forms/simple1/:id', component: ReactiveFormsValidationSimple1Component,
        resolve: {states: StateListResolver}
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
