import { Injectable } from '@angular/core';
import { Addressbook } from './../app.models';
import { Http } from '@angular/http';
import { GenericService } from './../Services/GenericService';

@Injectable()
export class AddressbookService extends GenericService<Addressbook> {
    constructor(http: Http) {
        super(http, '/api/AddressBookAPI');
    }
}