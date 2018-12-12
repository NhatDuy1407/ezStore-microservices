import { Component, OnInit } from '@angular/core';
import { WarehouseHttpService } from '../../../core/services/warehouse.service';
import { FormGroup, FormControl } from '@angular/forms';
import { NotifierService } from '../../../core/notifier/notifier.service';

@Component({
  templateUrl: 'warehouse-detail.component.html'
})
export class WarehouseDetailComponent implements OnInit {
  Id: string;
  warehouseForm: FormGroup;
  loading = false;
  constructor(private warehouseHttpService: WarehouseHttpService, private notifier: NotifierService) { }

  ngOnInit(): void {
    this.warehouseForm = new FormGroup({
      name: new FormControl(),
    });
  }

  async addEditItem() {
    // this.loading = true;
    // if (this.Id) {
    //   this.warehouseForm.value.SkillId = this.Id;
    //   await this.warehouseHttpService.put(this.apiUrl, this.warehouseForm.value).toPromise();
    //   this.notifier.showSuccess('Skill was updated', 'Skill');
    // } else {
    //   const newId = await this.warehouseHttpService.post(this.apiUrl, this.warehouseForm.value).toPromise();
    //   this.Id = newId.toString();
    //   this.notifier.showSuccess('Skill was created', 'Skill');
    // }
    // this.loading = false;
  }
}
