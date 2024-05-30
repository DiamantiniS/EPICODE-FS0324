import { Component, OnInit } from '@angular/core';
import { PhotoService, Photo } from '../../services/photo.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.scss'],
})
export class FavoritesComponent implements OnInit {
  favorites: Photo[] = [];
  favoriteCount: number = 0;

  constructor(private photoService: PhotoService) {}

  ngOnInit(): void {
    this.photoService.favorites$.subscribe((favorites) => {
      this.favorites = favorites;
    });

    this.photoService.getFavoriteCount().subscribe((count) => {
      this.favoriteCount = count;
    });
  }

  deleteFavorite(photo: Photo): void {
    this.photoService.removeFavorite(photo);
  }
}
