import { Component } from '@angular/core';
import { MoviesService } from '../../services/movies.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { iMovies } from '../../interfaces/iMovie.interface';

@Component({
  selector: 'app-new-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.scss'],
})
export class NewMovieComponent {
  movies: iMovies[] = [];
  createMovieForm!: FormGroup;

  constructor(
    private moviesService: MoviesService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.moviesService.loadMovies().subscribe((movies) => {
      this.movies = movies;
    });

    this.createMovieForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(1)]],
      duration: [, [Validators.required, Validators.min(1)]],
      rating: [, [Validators.required, Validators.min(1), Validators.max(10)]],
      image: ['', [Validators.required]],
      description: ['', [Validators.required, Validators.minLength(1)]],
    });
  }

  createMovie() {
    if (this.createMovieForm.valid) {
      const newMovie: iMovies = this.createMovieForm.value;
      this.moviesService.createMovie(newMovie).subscribe(() => {
        this.moviesService.loadMovies().subscribe((movies) => {
          this.movies = movies;
        });
        this.createMovieForm.reset({
          title: '',
          duration: 1,
          rating: 0,
          image: 'https://placedog.net/500',
          description: '',
        });
        this.router.navigate(['/dashboard']);
      });
    } else {
      console.log('Form is invalid');
    }
  }
}
