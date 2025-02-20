// src/app/components/product-list/product-list.component.ts
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../app/services/product.service';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  pageIndex: number = 1;
  pageSize: number = 10;
  totalProducts: number = 0;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService
      .getProducts(this.pageIndex)
      .subscribe((response: any) => {
        this.products = response.data;
        this.totalProducts = response.totalCount;
      });
  }

  previousPage(): void {
    if (this.pageIndex > 1) {
      this.pageIndex--;
      this.loadProducts();
    }
  }

  nextPage(): void {
    if (this.pageIndex * this.pageSize < this.totalProducts) {
      this.pageIndex++;
      this.loadProducts();
    }
  }
}
