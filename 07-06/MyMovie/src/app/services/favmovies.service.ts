import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, forkJoin, switchMap } from 'rxjs';
import { iMovies } from '../interfaces/iMovie.interface';
import { iFavMovies } from '../interfaces/iFavMovie.interface';

@Injectable({
  providedIn: 'root',
})
export class FavmoviesService {
  apiUrl: string = 'http://localhost:3000/favorites';

  constructor(private http: HttpClient) {}

  getAllFavMovies(): Observable<iFavMovies[]> {
    return this.http.get<iFavMovies[]>(this.apiUrl);
  }

  getFavMoviesByUserId(userId: number): Observable<iFavMovies[]> {
    return this.http.get<iFavMovies[]>(`${this.apiUrl}?userId=${userId}`);
  }

  createFav(newMovie: Partial<iFavMovies>): Observable<iFavMovies> {
    return this.http.post<iFavMovies>(this.apiUrl, newMovie);
  }

  delete(id: number): Observable<iFavMovies> {
    return this.http.delete<iFavMovies>(`${this.apiUrl}/${id}`);
  }

  loadFavoriteMovies(userId: number): Observable<iFavMovies[]> {
    return this.getFavMoviesByUserId(userId);
  }

  toggleFavourite(
    userId: number,
    movie: iMovies,
    favMovies: iFavMovies[]
  ): Observable<any> {
    const obj: Partial<iFavMovies> = {
      userId: userId,
      movie: movie,
    };

    const favMovie = favMovies.find(
      (fav) => fav.movie.id === movie.id && fav.userId === userId
    );
    if (favMovie) {
      return this.delete(favMovie.id);
    } else {
      return this.createFav(obj);
    }
  }
  deleteAllFavMoviesByMovieId(movieId: number): Observable<any> {
    return this.getAllFavMovies().pipe(
      switchMap((favMovies) => {
        const deleteObservables = favMovies
          .filter((fav) => fav.movie.id === movieId)
          .map((fav) => this.delete(fav.id));
        return forkJoin(deleteObservables);
      })
    );
  }
}
