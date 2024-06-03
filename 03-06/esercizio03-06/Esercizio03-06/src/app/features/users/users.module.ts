import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UsersDetailsPage } from './users-details.page';
import { UsersPage } from './users.page';
import { AuthGuard } from '../../auth/auth.guard';
import { NewUserPage } from './new-user.page';
import { FormsModule } from '@angular/forms';
import { DeactivateGuard } from '../../deactivate.guard';

const routes: Routes = [
  {
    path: 'new',
    component: NewUserPage,
    canDeactivate: [DeactivateGuard],
  },
  {
    path: '',
    component: UsersPage,
    canActivateChild: [AuthGuard],
    children: [
      {
        path: ':id',
        component: UsersDetailsPage,
      },
    ],
  },
];

@NgModule({
  declarations: [UsersPage, UsersDetailsPage, NewUserPage],
  imports: [CommonModule, RouterModule.forChild(routes), FormsModule],
})
export class UsersModule {}
