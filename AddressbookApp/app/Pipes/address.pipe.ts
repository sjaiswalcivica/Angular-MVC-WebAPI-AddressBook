import { Pipe, PipeTransform } from '@angular/core';
import { Addressbook } from './../app.models';

@Pipe({ name: "addressfilter" })
export class AddressFilter implements PipeTransform {

    transform(addresses: Addressbook[], txtSearch: any) {
        if (txtSearch == null)
            return addresses;
        else
            return addresses.filter(address =>
                address.FirstName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                address.LastName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                address.EmailId.toLowerCase().includes(txtSearch.toLowerCase()) ||
                address.Userdetail.UserName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                address.Street.toLowerCase().includes(txtSearch.toLowerCase()) ||
                address.City.toLowerCase().includes(txtSearch.toLowerCase()) ||
                address.State.StateName.toLowerCase().includes(txtSearch.toLowerCase()) 
            );
    }
}
