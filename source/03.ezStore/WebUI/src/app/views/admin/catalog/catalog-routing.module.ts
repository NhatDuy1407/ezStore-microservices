import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product.component';
import { ProductCategoryComponent } from './product-category.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Catalog'
    },
    children: [
      {
        path: 'product',
        component: ProductComponent,
        data: {
          title: 'Product'
        }
      },
      {
        path: 'product-category',
        component: ProductCategoryComponent,
        data: {
          title: 'Product Category'
        }
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogRoutingModule { }
