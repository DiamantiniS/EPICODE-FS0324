import { Component, OnInit } from '@angular/core';
import { SignUp } from '../../interfaces/auth.interface';
import { AuthService } from '../../services/auth.service';
import { IMovie } from '../../interfaces/movie.interface';
import { FilmsService } from '../../services/films.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss'],
})
export class ProfilePageComponent implements OnInit {
  movies: IMovie[] = [];

  constructor(private filmsService: FilmsService) {}

  ngOnInit(): void {
    this.loadAllMovies();
  }

  loadAllMovies(): void {
    this.filmsService.getAllMovies().subscribe(
      (movies: IMovie[]) => {
        this.movies = movies;
      },
      (error) => {
        console.error('Error loading movies:', error);
      }
    );
  }
}
