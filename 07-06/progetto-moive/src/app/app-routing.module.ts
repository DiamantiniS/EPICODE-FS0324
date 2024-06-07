import { FilmsComponent } from './pages/films/films.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninGuard } from './pages/signin/signin.guard';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { ProfilePageGuard } from './pages/profile-page/profile-page.guard';
import { AllUsersComponent } from './pages/all-users/all-users.component';

const routes: Routes = [
  {
    path: "login",
    // component: SigninComponent,
    loadChildren: () => import("./pages/signin/signin.module").then(m => m.SigninModule)
    , canActivate: [SigninGuard]
  },
  {
    path: "signup",
    // component: SignupComponent,
    loadChildren: () => import("./pages/signup/signup.module").then(m => m.SignupModule)
  },
  {
    path: "",
    component: ProfilePageComponent,
    canActivate: [ProfilePageGuard],
  },
  {
    path: "users",
    component: AllUsersComponent,
    canActivate: [ProfilePageGuard],
  },
  {
    path: "films",
    component: FilmsComponent,
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
