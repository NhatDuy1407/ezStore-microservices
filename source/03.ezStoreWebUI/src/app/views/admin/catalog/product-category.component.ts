import { Component, OnInit } from '@angular/core';
import { ProductHttpService } from '../../../core/services/product.service';

@Component({
  templateUrl: 'product-category.component.html'
})
export class ProductCategoryComponent implements OnInit {

  constructor(private productHttpService: ProductHttpService) { }

  ngOnInit(): void {
    this.productHttpService.getAllProductCategory().subscribe((data: any[]) => {
    });
  }
}
