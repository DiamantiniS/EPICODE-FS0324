import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Route } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/pages/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { InactivePostsComponent } from './components/pages/inactive-posts/inactive-posts.component';

import { ActivePostsComponent } from './components/pages/active-posts/active-posts.component';
import { PostDetailComponent } from './components/post-detail/post-detail.component';
import { SinglePageComponent } from './components/pages/single-page/single-page.component';
import { FormsModule } from '@angular/forms';



const routes: Route[] = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'active',
    component: ActivePostsComponent,
    title: 'Active Posts',
  },
  {
    path: 'inactive',
    component: InactivePostsComponent,
    title: 'Inactive Posts',
  },
  {
    path: 'post/:id',
    component: PostDetailComponent,
    title: 'Post Detail',
  },
  {
    path: 'singlepost',
    component: SinglePageComponent,
    title: 'Single Post',
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    ActivePostsComponent,
    InactivePostsComponent,
    PostDetailComponent,
    SinglePageComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
