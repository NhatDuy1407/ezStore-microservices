// Angular
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { CatalogRoutingModule } from './catalog-routing.module';
import { ProductHttpService } from '../../../core/services/product.service';
import { ProductComponent } from './product.component';
import { ProductCategoryComponent } from './product-category.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CatalogRoutingModule,
  ],
  providers: [
    ProductHttpService
  ],
  declarations: [
    ProductComponent,
    ProductCategoryComponent,
  ]
})
export class CatalogModule { }
