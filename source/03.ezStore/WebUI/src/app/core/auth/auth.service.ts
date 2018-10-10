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

    constructor(private router: Router, http: HttpClient, private notifierService: NotifierService) {
        super(http);
    }

    public hash_token: string = null;

    async login(username, password) {
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
                    this.router.navigate(['/']);
                }
            },
                error => {
                    // error: {error: "invalid_grant", error_description: "invalid_username_or_password"}
                    if (error.error.error_description === 'invalid_username_or_password') {
                        this.notifierService.error('Invalid username or password', 'Login');
                    }
                });
    }

    isAuthenticate(): boolean {
        return localStorage.getItem('access_token') !== null;
    }

    logout() {
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
