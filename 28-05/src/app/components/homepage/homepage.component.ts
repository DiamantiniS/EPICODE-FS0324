import { Component, InputOptionsWithoutTransform } from '@angular/core';
import { iPosts } from '../../models/iposts';
import { PostsService } from '../../posts.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.scss'
})
export class HomepageComponent {
  post!: iPosts;
  posts: iPosts[] = [];
  related: iPosts[] = [];

  constructor(
    private postsSvc:PostsService
  ){}

  ngOnInit() {
      this.getTopPost();
  }

  async getTopPost() {

      this.posts = this.postsSvc.getAllPosts();
      const indice = Math.floor(Math.random() * this.posts.length);
      this.post = this.posts[indice];
      this.getRelated(4);
  }

  getRelated(num: number) {
      const presenti: number[] = []
      for (let i = 0; i < num; i++) {
          const indice = Math.floor(Math.random() * this.posts.length);
          if (presenti.includes(indice)) this.getRelated(num - i);
          presenti.push(indice);
          this.related.push(this.posts[indice]);
      }
      console.log(this.related);
  }
}

