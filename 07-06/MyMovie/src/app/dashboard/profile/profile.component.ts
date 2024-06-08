import { Component } from '@angular/core';
import { AuthService } from '../../auth/auth.service';

import { UserService } from '../../services/users.service';
import { iUsers } from '../../interfaces/iUsers.interface';

import { FavmoviesService } from '../../services/favmovies.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent {
  user!: iUsers | null;
  users: iUsers[] = [];
  numFavorites: number = 0;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private favMoviesService: FavmoviesService
  ) {}

  ngOnInit() {
    this.authService.user$.subscribe((user: iUsers | null) => {
      this.user = user;
      if (this.user) {
        this.favMoviesService
          .getFavMoviesByUserId(this.user.id)
          .subscribe((favMovies) => {
            this.numFavorites = favMovies.length;
          });
      }
    });
  }
}
