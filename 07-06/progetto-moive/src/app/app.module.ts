import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { AllUsersComponent } from './pages/all-users/all-users.component';
import { ProfilePageComponent } from './pages/profile-page/profile-page.component';
import { FilmsComponent } from './pages/films/films.component';


@NgModule({
  declarations: [
    AppComponent,
    AllUsersComponent,
    ProfilePageComponent,
    FilmsComponent
  ],
 imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
