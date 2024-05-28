import { Route, RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { ActivePostComponent } from './components/active-post/active-post.component';
import { InactivePostComponent } from './components/inactive-post/inactive-post.component';
import { PostDetailsComponent } from './components/post-details/post-details.component';
import { SinglePostComponent } from './components/single-post/single-post.component';
import { FormsModule } from '@angular/forms';

const routes: Route[] = [
  {
    path: '',
    component: HomepageComponent,
  },
  {
    path: 'post/:id',
    component: PostDetailsComponent,
  },
  {
    path: 'active',
    component: ActivePostComponent,
  },
  {
    path: 'inactive',
    component: InactivePostComponent,
  },
  {
    path: 'singlepost',
    component: SinglePostComponent,
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeaderComponent,
    FooterComponent,
    HomepageComponent,
    ActivePostComponent,
    InactivePostComponent,
    PostDetailsComponent,
    SinglePostComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule.forRoot(routes),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
