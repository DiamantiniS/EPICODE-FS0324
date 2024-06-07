import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMovie } from '../interfaces/movie.interface';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FilmsService {
  constructor(private http: HttpClient) {}

  getAllMovies(): Observable<IMovie[]> {
    return this.http.get<IMovie[]>(`${environment.srvr}movies`);
  }
}
