import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = 'https://dummyjson.com/products';
  private favorites = new Subject<Product[]>();
  private cart = new Subject<Product[]>();

  private currentFavorites: Product[] = [];
  private currentCart: Product[] = [];

  constructor(private http: HttpClient) {}

  getProducts(): Observable<{ products: Product[] }> {
    return this.http.get<{ products: Product[] }>(this.apiUrl);
  }

  getFavorites(): Observable<Product[]> {
    return this.favorites.asObservable();
  }

  addToFavorites(product: Product) {
    if (!this.currentFavorites.find((p: Product) => p.id === product.id)) {
      this.currentFavorites.push(product);
      this.favorites.next(this.currentFavorites);
    }
  }

  removeFromFavorites(productId: number) {
    this.currentFavorites = this.currentFavorites.filter(
      (p: Product) => p.id !== productId
    );
    this.favorites.next(this.currentFavorites);
  }

  getCart(): Observable<Product[]> {
    return this.cart.asObservable();
  }

  addToCart(product: Product) {
    this.currentCart.push(product);
    this.cart.next(this.currentCart);
  }

  removeFromCart(productId: number) {
    this.currentCart = this.currentCart.filter(
      (p: Product) => p.id !== productId
    );
    this.cart.next(this.currentCart);
  }
}
