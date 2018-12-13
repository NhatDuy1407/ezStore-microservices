import { Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { NotifierService } from '../notifier/notifier.service';

export interface Auth {
    userName: string;
    password: string;
}

@Injectable()
export class AuthService extends HttpService {
    get api() {
        return environment.identityServiceUrl;
    }

    constructor(private router: Router, http: HttpClient) {
        super(http);
    }

    public hash_token: string = null;

    login(username, password, callback?, errorCallBack?) {
        const body = new HttpParams()
            .set('grant_type', 'password')
            .set('username', username)
            .set('password', password)
            .set('scope', 'apiApp openid profile')
            .set('client_id', 'clientApp')
            .set('client_secret', 'secret');

        this.post('connect/token', body.toString(),
            { headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' }) }).subscribe((tokenData: any) => {
                if (tokenData) {
                    localStorage.setItem('access_token', tokenData.access_token);
                    if (callback) { callback(); }
                    this.router.navigate(['/']);
                }
            }, () => {
                if (errorCallBack) {
                    errorCallBack();
                }
            });
    }

    register(data, callback?, errorCallBack?) {
        this.post('api/registerUser', data
        ).subscribe(() => {
            if (callback) {
                callback();
            }
        }, () => {
            if (errorCallBack) {
                errorCallBack();
            }
        });
    }

    isAuthenticate(): boolean {
        return localStorage.getItem('access_token') !== null;
    }

    logout() {
        localStorage.removeItem('access_token');
        this.router.navigate(['dashboard']);
    }

    getUserInfo() {
    }

    getUserId() {
    }

    // userIsExit(userId: string): Observable<boolean> {
    // }

    // createUser(userId) {
    // }

    // getUserRole(): Observable<string> {
    // }
}
