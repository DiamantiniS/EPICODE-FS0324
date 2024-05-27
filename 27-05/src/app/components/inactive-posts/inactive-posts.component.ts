import { Component } from '@angular/core';
import { Post } from 'src/app/models/post.interface';


@Component({
  selector: 'app-inactive-posts',
  templateUrl: './inactive-posts.component.html',
  styleUrls: ['./inactive-posts.component.scss']
})
export class InactivePostsComponent {
    posts: Post[] = [];

    ngOnInit(): void {
        this.getInactivePosts().then((res) => {
            this.posts = res;
        });
    }

    async getInactivePosts() {
        const response = await fetch('../../assets/db.json');
        const postsResponse = (await response.json()) as Array<Post>;
        return postsResponse.filter((post) => !post.active);
    }

}
