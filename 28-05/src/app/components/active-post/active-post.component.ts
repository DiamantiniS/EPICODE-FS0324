import { Component } from '@angular/core';
import { iPosts } from '../../models/iposts';
import { PostsService } from '../../posts.service';

@Component({
  selector: 'app-active-post',
  templateUrl: './active-post.component.html',
  styleUrl: './active-post.component.scss',
})
export class ActivePostComponent {
  posts: iPosts[] = [];

  constructor(private postsSvc: PostsService) {}

  ngOnInit(): void {
    this.posts = this.postsSvc.getActivePosts();
  }
}
