import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomerComponent } from './customer.component';
import { CustomerRoleComponent } from './customer-role.component';
const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Customer'
    },
    children: [
      {
        path: 'list',
        component: CustomerComponent,
        data: {
          title: 'Customer'
        }
      },
      {
        path: 'customer-role',
        component: CustomerRoleComponent,
        data: {
          title: 'Customer Role'
        }
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
