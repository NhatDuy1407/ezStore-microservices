import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WarehouseComponent } from './warehouse.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Setting'
    },
    children: [
      {
        path: 'warehouse',
        component: WarehouseComponent,
        data: {
          title: 'Warehouse'
        }
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }
