import { Component } from '@angular/core';
import { Post } from 'src/app/models/post.interface';


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
    post!: Post;
    posts: Post[] = [];
    related: Post[] = [];

    ngOnInit() {
        this.getTopPost();
    }

    async getTopPost() {
        const response = await fetch('../../assets/db.json');
        const postsResponse = response;
        this.posts = await postsResponse.json();
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
