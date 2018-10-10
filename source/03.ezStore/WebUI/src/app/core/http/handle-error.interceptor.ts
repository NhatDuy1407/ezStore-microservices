import { Injectable } from '@angular/core';
import { NotifierService } from '../notifier/notifier.service';
import { HttpInterceptor } from '@angular/common/http/src/interceptor';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { HttpEvent, HttpRequest, HttpHandler, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable()
export class HandleErrorInterceptor implements HttpInterceptor {
    constructor(private notification: NotifierService, private _router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        /* istanbul ignore next */
        if (req.responseType === 'json') {
            req = req.clone({ responseType: 'text' });

            return next.handle(req).pipe(
                map(response => {
                    if (response instanceof HttpResponse && this.isJSON(response.body)) {

                        response = response.clone<any>({ body: JSON.parse(response.body) });
                    }

                    return response;
                }),
                tap((event: HttpEvent<any>) => { }, (err: any) => {
                    if (err instanceof HttpErrorResponse) {
                        if (err.status === 401) {
                            this._router.navigate(['login']);
                        } else if (err.error && Object.keys(err.error).length > 0) {
                            const msg = err.message || '';
                            this.notification.error(msg, 'Http Error');
                        }
                    }
                }));
        }

        return next.handle(req);
    }

    // vanillaJS
    isJSON(str) {
        try {
            return (JSON.parse(str) && !!str);
        } catch (e) {
            return false;
        }
    }
}

