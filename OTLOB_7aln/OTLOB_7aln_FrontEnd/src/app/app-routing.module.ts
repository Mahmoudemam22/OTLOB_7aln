import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from '.././components/product-list/product-list.component';
import { ProductDetailsComponent } from '.././components/product-details/product-details.component';
import { BrandListComponent } from '.././components/brand-list/brand-list.component';

const routes: Routes = [
  { path: '', component: ProductListComponent },
  { path: 'products/:id', component: ProductDetailsComponent },
  { path: 'brands', component: BrandListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
