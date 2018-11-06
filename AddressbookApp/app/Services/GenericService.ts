import { Http, Response, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/observable';
import { IGenericService } from './IGenericService';

export abstract class GenericService<T> implements IGenericService<T> {
    constructor(protected http:Http,private url:string) { }

    GetAll(): Observable<T[]> {
        return this.http.get(this.url)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }
    Get(id: any): Observable<T> {
        const url = `${this.url}/${id}`;
        return this.http.get(url)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }
    Add(entity: T): Observable<T[]> {
        let data = JSON.stringify(entity);
        let headers: Headers = new Headers({ "content-type": "application/json" });
        let options: RequestOptions = new RequestOptions({ headers: headers });
        return this.http.post(this.url, data, options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }
    Edit(entity: T): Observable<T[]> {
        let data = JSON.stringify(entity);
        console.log(entity);
        let headers: Headers = new Headers({ "content-type": "application/json" });
        let options: RequestOptions = new RequestOptions({ headers: headers });
        return this.http.put(this.url, data, options)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }
    Delete(id: any): Observable<T[]> {
        const url = `${this.url}/${id}`;
        return this.http.delete(url)
            .map((res: Response) => res.json())
            .catch(this.handleError);
    }

    handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

}
