import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Route, RouterModule } from '@angular/router';
import { SigninComponent } from './signin.component';

const routes:Route[] = [
  {
    path: "",
    component: SigninComponent
  }
]

@NgModule({
  declarations: [
    SigninComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes)
  ]
})
export class SigninModule { }
