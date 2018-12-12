import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboadModule } from './dashboard/dashboad.module';
import { CatalogModule } from './catalog/catalog.module';
import { CustomerModule } from './customer/customer.module';
import { SettingModule } from './setting/setting.module';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Admin'
    },
    children: [
      {
        path: 'dashboard',
        loadChildren: () => DashboadModule,
      },
      {
        path: 'catalog',
        loadChildren: () => CatalogModule
      },
      {
        path: 'customer',
        loadChildren: () => CustomerModule
      },
      {
        path: 'setting',
        loadChildren: () => SettingModule
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
