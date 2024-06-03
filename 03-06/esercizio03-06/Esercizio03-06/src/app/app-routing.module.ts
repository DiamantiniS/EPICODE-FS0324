import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

const routes: Route[] = [
  {
    path: '',
    loadChildren: () =>
      import('./features/home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'users',
    loadChildren: () =>
      import('./features/users/users.module').then((m) => m.UsersModule),
  },
  {
    path: 'active-posts',
    loadChildren: () =>
      import('./features/active-posts/active-posts.module').then(
        (m) => m.ActivePostsModule
      ),
  },
  {
    path: 'inactive-posts',
    canActivate:[AuthGuard],
    loadChildren: () =>
      import('./features/inactive-posts/inactive-posts.module').then(
        (m) => m.InactivePostsModule
      ),
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
