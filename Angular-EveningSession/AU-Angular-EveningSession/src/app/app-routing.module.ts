import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ThirdComponent } from './third/third.component';

const routes: Routes = [
  { path: 'component1', component: ThirdComponent },
  { path: 'component2', component: ThirdComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
