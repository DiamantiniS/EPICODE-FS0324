import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './main-components/header/header.component';
import { ActivePostsComponent } from './main-components/active-posts/active-posts.component';
import { IncativePostsComponent } from './main-components/incative-posts/incative-posts.component';
import { PostDetailComponent } from './main-components/post-detail/post-detail.component';
import { NavbarComponent } from './main-components/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ActivePostsComponent,
    IncativePostsComponent,
    PostDetailComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
