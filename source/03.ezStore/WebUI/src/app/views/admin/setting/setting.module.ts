// Angular
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { WarehouseComponent } from './warehouse.component';
import { WarehouseHttpService } from '../../../core/services/warehouse.service';
import { SettingRoutingModule } from './setting-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SettingRoutingModule
  ],
  providers: [
    WarehouseHttpService
  ],
  declarations: [
    WarehouseComponent,
  ]
})
export class SettingModule { }
