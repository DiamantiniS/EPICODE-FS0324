import { Component, OnInit } from '@angular/core';
import { PhotoService } from '../../services/photo.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  favoriteCount: number = 0;

  constructor(private photoService: PhotoService) {}

  ngOnInit(): void {
    this.photoService.getFavoriteCount().subscribe((count) => {
      this.favoriteCount = count;
    });
  }
}
