import { Component, OnInit } from '@angular/core';
import { WarehouseHttpService } from '../../../core/services/warehouse.service';
import { FormGroup, FormControl } from '@angular/forms';
import { PagedResult } from '../../../core/model/paged-result.model';
import { WareHouseModel } from '../../../core/model/warehouse.model';

@Component({
  templateUrl: 'warehouse.component.html'
})
export class WarehouseComponent implements OnInit {
  warehouseForm: FormGroup;
  constructor(private warehouseHttpService: WarehouseHttpService) { }

  ngOnInit(): void {
    this.warehouseForm = new FormGroup({
      name: new FormControl(),
    });
  }

  searchItem() {
    this.warehouseHttpService.getPaged(this.warehouseForm.value.name, ``, true, 1, 20).subscribe((result: PagedResult<WareHouseModel>) => {

    });
  }
}
