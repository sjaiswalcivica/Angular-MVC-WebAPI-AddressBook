import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/observable';
import { LoginModel } from './../app.models';

@Injectable()
export class AuthenticateService {
    constructor(private http:Http) {

    }

    AuthenticateUser(login: LoginModel): Observable<LoginModel> {
        const url = `${'/api/AuthenticateAPI'}`;
        let data = JSON.stringify(login);
        let headers: Headers = new Headers({ "content-type": "application/json" });
        let options: RequestOptions = new RequestOptions({ headers: headers });
        return this.http.post(url, data, options).map((res: Response) => res.json());
    }
}

