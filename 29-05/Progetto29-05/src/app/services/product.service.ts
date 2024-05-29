import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = 'https://dummyjson.com/products';
  private favorites = new BehaviorSubject<any[]>([]);
  private cart = new BehaviorSubject<any[]>([]);

  constructor(private http: HttpClient) {}

  getProducts(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }

  getFavorites(): Observable<any[]> {
    return this.favorites.asObservable();
  }

  addToFavorites(product: any) {
    const currentFavorites = this.favorites.getValue();
    if (!currentFavorites.find((p) => p.id === product.id)) {
      this.favorites.next([...currentFavorites, product]);
    }
  }

  removeFromFavorites(productId: number) {
    const updatedFavorites = this.favorites
      .getValue()
      .filter((p) => p.id !== productId);
    this.favorites.next(updatedFavorites);
  }

  getCart(): Observable<any[]> {
    return this.cart.asObservable();
  }

  addToCart(product: any) {
    const currentCart = this.cart.getValue();
    this.cart.next([...currentCart, product]);
  }

  removeFromCart(productId: number) {
    const updatedCart = this.cart.getValue().filter((p) => p.id !== productId);
    this.cart.next(updatedCart);
  }
}
