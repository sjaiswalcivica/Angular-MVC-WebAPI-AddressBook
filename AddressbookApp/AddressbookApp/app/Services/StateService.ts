import { State, Country } from './../app.models';
import { Http } from '@angular/http';
import { GenericService } from './GenericService';
import { Injectable} from '@angular/core';

@Injectable()
export class StateService extends GenericService<State> {
    constructor(http: Http) {
        super(http, '/api/StatesAPI');
    }
}