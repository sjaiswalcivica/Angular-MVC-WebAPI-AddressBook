import { Country } from './../app.models';
import { Injectable } from '@angular/core';
import { GenericService } from './GenericService';
import { Http} from '@angular/http';

@Injectable()
export class CountryService extends GenericService<Country> {
    constructor(http:Http) {
        super(http, "/api/CountryAPI");       
    }
}