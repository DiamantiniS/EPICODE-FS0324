import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MoviesService } from '../../services/movies.service';
import { iMovies } from '../../interfaces/iMovie.interface';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent {
  movieId!: number;
  movie!: iMovies;

  constructor(
    private route: ActivatedRoute,
    private moviesService: MoviesService
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.movieId = +params['id'];
      this.loadDetails(this.movieId);
    });
  }

  loadDetails(id: number): void {
    this.moviesService.getById(id).subscribe((movie) => {
      this.movie = movie;
    });
  }
}
