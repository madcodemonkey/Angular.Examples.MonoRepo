import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './features/home/home.component';
import { OtherPageComponent } from './features/other-page/other-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    OtherPageComponent
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
