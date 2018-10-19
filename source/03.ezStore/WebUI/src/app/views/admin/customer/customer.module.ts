// Angular
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

// Components Routing
import { ProductHttpService } from '../../../core/services/product.service';
import { CustomerComponent } from './customer.component';
import { CustomerRoleComponent } from './customer-role.component';
import { CustomerRoutingModule } from './customer-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CustomerRoutingModule,
  ],
  providers: [
    ProductHttpService
  ],
  declarations: [
    CustomerComponent,
    CustomerRoleComponent,
  ]
})
export class CustomerModule { }
