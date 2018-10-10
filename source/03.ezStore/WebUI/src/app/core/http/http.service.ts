import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export abstract class HttpService {
    private http: HttpClient;
    abstract get api();

    constructor(http: HttpClient) {
        this.http = http;
    }

    protected get(resource: string) {
        const url = this.api + resource;
        return this.http.get(url);
    }

    protected put(resource: string, body: any) {
        const url = this.api + resource;
        return this.http.put(url, body);
    }

    protected post(resource: string, body: any, option?: any) {
        const url = this.api + resource;
        return this.http.post(url, body, option);
    }

    protected delete(resource: string) {
        const url = this.api + resource;
        return this.http.delete(url);
    }
}
