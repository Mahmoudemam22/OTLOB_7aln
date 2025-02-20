import { Component, OnInit } from '@angular/core';
import { BrandService } from '../../services/brand.service';
import { ProductBrand } from '../../models/product-brand.model';

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent implements OnInit {
  brands: ProductBrand[] = [];

  constructor(private brandService: BrandService) {}

  ngOnInit() {
    this.brandService.getBrands().subscribe(data => {
      this.brands = data;
    });
  }
}
