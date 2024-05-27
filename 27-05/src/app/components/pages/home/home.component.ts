import { Component } from '@angular/core';
import { Post } from '../../../models/post.interface';
import { BlogService } from '../../../blog.service';


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
    post!: Post;
    posts: Post[] = [];
    related: Post[] = [];

    constructor(
      private blogSvc:BlogService
    ){}

    ngOnInit() {
        this.getTopPost();
    }

    async getTopPost() {

        this.posts = this.blogSvc.getAllPosts();
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
