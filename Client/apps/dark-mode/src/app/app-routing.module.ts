import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { OtherPageComponent } from './features/other-page/other-page.component';

const routes: Routes = [
  { path: '', component: HomeComponent  },
  { path: 'other', component: OtherPageComponent}
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
