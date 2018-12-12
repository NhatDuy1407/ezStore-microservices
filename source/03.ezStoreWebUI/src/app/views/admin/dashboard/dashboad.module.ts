// Angular
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

// Components Routing
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { DashboadRouteModule } from './dashboad-routing.module';
import { DashboardComponent } from './dashboard.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DashboadRouteModule,
    ChartsModule,
    BsDropdownModule,
    ButtonsModule.forRoot()
  ],
  providers: [
  ],
  declarations: [
    DashboardComponent,
  ]
})
export class DashboadModule { }
