import { Component, OnInit } from '@angular/core';
import { PhotoService, Photo } from '../../services/photo.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  photos: Photo[] = [];
  favoriteCount: number = 0;

  constructor(private photoService: PhotoService) {}

  ngOnInit(): void {
    this.photoService.getPhotos().subscribe((photos) => {
      this.photos = photos;
    });

    this.photoService.getFavoriteCount().subscribe((count) => {
      this.favoriteCount = count;
    });
  }

  likePhoto(photo: Photo): void {
    this.photoService.addFavorite(photo);
  }

  deleteFavorite(photo: Photo): void {
    this.photoService.removeFavorite(photo);
  }
}
