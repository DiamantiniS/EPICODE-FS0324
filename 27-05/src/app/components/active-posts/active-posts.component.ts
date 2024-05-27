import { Component } from '@angular/core';
import { Post } from 'src/app/models/post.interface';
;


@Component({
    selector: 'app-active-posts',
    templateUrl: './active-posts.component.html',
    styleUrls: ['./active-posts.component.scss'],
})
export class ActivePostsComponent {
    posts: Post[] = [];

    ngOnInit(): void {
        this.getActivePosts().then((res) => {
            this.posts = res;
        });
    }

    async getActivePosts() {
        const response = await fetch('../../assets/db.json');
        const postsResponse = (await response.json()) as Array<Post>;
        return postsResponse.filter((post) => post.active);
    }
}
