import { Userdetail } from './../app.models';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/observable';
import { GenericService } from './GenericService';
import { Http, Response, RequestOptions, Headers } from '@angular/http';

@Injectable()
export class UserService extends GenericService<Userdetail> {
    constructor(http: Http) {
        super(http, "/api/UserDetailsAPI");
    }

    GetLoginUser(): Observable<Userdetail> {
        return this.http.get('/api/UserDetailsAPI/GetLoginUser')
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    Logout(): Observable<string> {
        let data = {};
        let headers: Headers = new Headers({ "content-type": "application/json" });
        let options: RequestOptions = new RequestOptions({ headers: headers });
        return this.http.post('/Login/LogOff', data, options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }   
}