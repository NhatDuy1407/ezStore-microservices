import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { environment } from '../../../environments/environment';

@Injectable()
export class IdentityHttpService extends HttpService {
    get api() {
        return environment.identityServiceUrl;
    }
}
