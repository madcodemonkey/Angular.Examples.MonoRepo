import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './material/material.module';

import { AppComponent } from './app.component';
import { DownloadFileExampleComponent } from './features/downloadfile/download-file-example.component';
import { HomeComponent } from './features/home/home.component';
import { TemplateFormsValidationSimple1Component } from './features/validation/template-forms-validation-simple1/template-forms-validation-simple1.component';
import { ReactiveFormsValidationSimple1Component } from './features/validation/reactive-forms-validation-simple1/reactive-forms-validation-simple1.component';
import { CascadeDropdownListComponent } from './features/dropdown/cascade-dropdown-list/cascade-dropdown-list.component';

@NgModule({
  declarations: [
    AppComponent,
    DownloadFileExampleComponent,
    HomeComponent,
    TemplateFormsValidationSimple1Component,
    ReactiveFormsValidationSimple1Component,
    CascadeDropdownListComponent,
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
