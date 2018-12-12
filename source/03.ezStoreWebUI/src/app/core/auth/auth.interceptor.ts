import { HttpInterceptor, HttpEvent, HttpRequest, HttpHandler } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private _auth: AuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this._auth.isAuthenticate()) {
            const token = localStorage.getItem('access_token');

            const newReq = req.clone({
                setHeaders: {
                    'AUTHORIZATION': `Bearer ${token}`
                }
            });

            return next.handle(newReq);
        }

        return next.handle(req);
    }
}
