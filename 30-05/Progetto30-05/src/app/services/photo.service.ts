import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { catchError, map } from 'rxjs/operators'; // Aggiungi map qui

export interface Photo {
  id: number;
  title: string;
  url: string;
  thumbnailUrl: string;
}

@Injectable({
  providedIn: 'root',
})
export class PhotoService {
  private apiUrl = 'https://jsonplaceholder.typicode.com/photos';
  private favoritesSubject = new BehaviorSubject<Photo[]>([]);
  favorites$ = this.favoritesSubject.asObservable();

  constructor(private http: HttpClient) {}

  getPhotos(): Observable<Photo[]> {
    return this.http
      .get<Photo[]>(this.apiUrl)
      .pipe(catchError(this.handleError));
  }

  deletePhoto(id: number): Observable<{}> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('An error occurred:', error);
    return throwError('Something bad happened; please try again later.');
  }

  addFavorite(photo: Photo): void {
    const currentFavorites = this.favoritesSubject.value;
    this.favoritesSubject.next([...currentFavorites, photo]);
  }

  removeFavorite(photo: Photo): void {
    const currentFavorites = this.favoritesSubject.value.filter(
      (fav) => fav.id !== photo.id
    );
    this.favoritesSubject.next(currentFavorites);
  }

  getFavoriteCount(): Observable<number> {
    return this.favorites$.pipe(map((favorites) => favorites.length));
  }
}
