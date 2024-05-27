import { Component } from '@angular/core';
import { Post } from '../../../models/post.interface';
import { BlogService } from '../../../blog.service';




@Component({
    selector: 'app-active-posts',
    templateUrl: './active-posts.component.html',
    styleUrls: ['./active-posts.component.scss'],
})
export class ActivePostsComponent {
    posts: Post[] = [];
    constructor(
      private blogSvc:BlogService
    ){}

    ngOnInit(): void {
      this.posts = this.blogSvc.getActivePosts();

    }


}
