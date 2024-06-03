import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { InactivePostsPage } from './inactive-posts.page';
import { PostDetailsPage } from '../../shared/post-details.page';
import { SharedModule } from '../../shared/shared.module';
import { PostsService } from '../../posts.service';

const routes: Routes = [
  { path: '', component: InactivePostsPage },
  {
    path: ':id',
    component: PostDetailsPage,
  },
];

@NgModule({
  declarations: [InactivePostsPage],
  imports: [CommonModule, RouterModule.forChild(routes), SharedModule],
})
export class InactivePostsModule {}
