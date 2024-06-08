import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FavoritesComponent } from './favorites/favorites.component';
import { ProfileComponent } from './profile/profile.component';
import { NewMovieComponent } from './add-movie/add-movie.component';
import { DetailsComponent } from './details/details.component';

@NgModule({
  declarations: [
    DashboardComponent,
    NewMovieComponent,
    FavoritesComponent,
    ProfileComponent,
    DetailsComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class DashboardModule {}
