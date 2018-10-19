import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { environment } from '../../../environments/environment';
import { NotifierService } from '../notifier/notifier.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ProductHttpService extends HttpService {
    get api() {
        return environment.productServiceUrl;
    }

    constructor(private notifierService: NotifierService, http: HttpClient) {
        super(http);
    }

    getAllProductCategory(): Observable<any[]> {
        return this.get<any[]>('productCategory');
    }
}
