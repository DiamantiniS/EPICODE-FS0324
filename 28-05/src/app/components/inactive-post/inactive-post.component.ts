import { Component } from '@angular/core';
import { iPosts } from '../../models/iposts';
import { PostsService } from '../../posts.service';

@Component({
  selector: 'app-inactive-post',
  templateUrl: './inactive-post.component.html',
  styleUrl: './inactive-post.component.scss',
})
export class InactivePostComponent {
  posts: iPosts[] = [];

  constructor(private postsSvc: PostsService) {}

  ngOnInit(): void {
    this.posts = this.postsSvc.getInactivePosts();
  }
}
