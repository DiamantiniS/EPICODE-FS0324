import { Component } from '@angular/core';
import { iPosts } from '../../models/iposts';
import { PostsService } from '../../posts.service';

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrl: './single-post.component.scss',
})
export class SinglePostComponent {
  post!: iPosts;
  posts: iPosts[] = [];
  related: iPosts[] = [];

  constructor(private postsSvc: PostsService) {}

  ngOnInit(): void {
    this.posts = this.postsSvc.getAllPosts();
    this.related = this.postsSvc.getAllPosts();
    this.posts = this.ordinaPost();
  }

  ordinaPost(): iPosts[] {
    const selectedTags = new Set<string>();
    const uniquePosts: iPosts[] = [];

    for (const post of this.posts) {
      const postHasNewTag = post.tags.some((tag) => !selectedTags.has(tag));

      if (postHasNewTag) {
        uniquePosts.push(post);
        post.tags.forEach((tag) => selectedTags.add(tag));
      }
    }
    return uniquePosts;
  }

  modificaPost(): void {}

  selezionaTag(t: string): void {
    this.posts = this.related.filter((post) => post.tags.includes(t));
  }
}
