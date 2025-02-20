import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductBrand } from '../models/product-brand.model';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  private baseUrl = 'http://localhost:5000/api/products/brands';

  constructor(private http: HttpClient) {}

  getBrands(): Observable<ProductBrand[]> {
    return this.http.get<ProductBrand[]>(this.baseUrl);
  }
}
