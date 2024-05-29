import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrl: './favorites.component.scss',
})
export class FavoritesComponent implements OnInit {
  favorites: any[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getFavorites().subscribe((data) => {
      this.favorites = data;
    });
  }

  removeFromFavorites(productId: number) {
    this.productService.removeFromFavorites(productId);
  }
}
