import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { environment } from '../../../environments/environment';
import { NotifierService } from '../notifier/notifier.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WareHouseModel } from '../model/warehouse.model';
import { PagedResult } from '../model/paged-result.model';

@Injectable()
export class WarehouseHttpService extends HttpService {
    get api() {
        return environment.warehouseServiceUrl;
    }

    constructor(private notifierService: NotifierService, http: HttpClient) {
        super(http);
    }

    getPaged(
        name: string,
        orderBy: string,
        orderAsc: boolean = true,
        page: number = 1,
        size: number = 20): Observable<PagedResult<WareHouseModel>> {
        return this.get<PagedResult<WareHouseModel>>(
            `wareHouse?name=${name}&orderBy=${orderBy}&orderAsc=${orderAsc}&page=${page}&size=${size}`
        );
    }
}
