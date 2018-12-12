import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product.component';
import { ProductCategoryComponent } from './product-category.component';
import { ManufactureComponent } from './manufacture.component';

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
      {
        path: 'manufacture',
        component: ManufactureComponent,
        data: {
          title: 'Manufacture'
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
