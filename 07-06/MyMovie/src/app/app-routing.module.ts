import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from './auth/auth.guard';
import { NaviGuard } from './auth/navigation.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('../app/main-components/home/home.module').then(
        (m) => m.HomeModule
      ),
    title: 'Home',
    canActivate: [NaviGuard],
    canActivateChild: [NaviGuard],
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
    canActivate: [NaviGuard],
    canActivateChild: [NaviGuard],
  },
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
    title: 'Dashboard',
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
