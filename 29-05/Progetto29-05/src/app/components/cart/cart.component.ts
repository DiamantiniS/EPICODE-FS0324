import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss',
})
export class CartComponent implements OnInit {
  cart: any[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getCart().subscribe((data) => {
      this.cart = data;
    });
  }

  removeFromCart(productId: number) {
    this.productService.removeFromCart(productId);
  }
}
