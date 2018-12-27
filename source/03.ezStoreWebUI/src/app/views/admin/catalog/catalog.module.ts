// Angular
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { CatalogRoutingModule } from './catalog-routing.module';
import { ProductHttpService } from '../../../core/services/product.service';
import { ProductComponent } from './product.component';
import { ProductCategoryComponent } from './product-category.component';
import { ManufactureComponent } from './manufacture.component';
import { FileSystemService } from '../../../core/services/filesystem.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CatalogRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [
    ProductHttpService,
    FileSystemService
  ],
  declarations: [
    ProductComponent,
    ProductCategoryComponent,
    ManufactureComponent,
  ]
})
export class CatalogModule { }
