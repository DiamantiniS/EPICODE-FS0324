import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { ProfilePageGuard } from './components/profile-page/profile-page.guard';
import { SigninGuard } from './components/signin/signin.guard';

const routes: Routes = [
  {
    path: "login",
    // component: SigninComponent,
    loadChildren: () => import("./components/signin/signin.module").then(m => m.SigninModule)
    , canActivate: [SigninGuard]
  },
  {
    path: "signup",
    // component: SignupComponent,
    loadChildren: () => import("./components/signup/signup.module").then(m => m.SignupModule)
  },
  {
    path: "",
    component: ProfilePageComponent,
    canActivate: [ProfilePageGuard],
  },
  // {
  //   path: "**",
  //   redirectTo: "login"
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
