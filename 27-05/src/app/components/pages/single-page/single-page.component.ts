import { Component } from '@angular/core';
import { Post } from '../../../models/post.interface';
import { BlogService } from '../../../blog.service';

@Component({
  selector: 'app-single-page',
  templateUrl: './single-page.component.html',
  styleUrl: './single-page.component.scss'
})
export class SinglePageComponent {
  posts: Post[] = [];
  constructor(
    private blogSvc:BlogService
  ){}

  ngOnInit(): void {
    this.posts = this.blogSvc.getAllPosts();

  }

  modificaPost(): void {


  }


}
