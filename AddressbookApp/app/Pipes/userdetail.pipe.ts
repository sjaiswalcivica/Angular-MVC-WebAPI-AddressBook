import { Pipe, PipeTransform } from '@angular/core';
import { Userdetail } from './../app.models';

@Pipe({ name: "userdetailfilter" })
export class UserDetailFilter implements PipeTransform {

    transform(users: Userdetail[], txtSearch: any) {

        if (txtSearch == null || txtSearch == "" || txtSearch == undefined)
            return users;
        else
            return users.filter(user =>
                user.UserName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                user.FirstName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                user.LastName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                user.Password.toLowerCase().includes(txtSearch.toLowerCase()) ||
                user.EmailId.toLowerCase().includes(txtSearch.toLowerCase()) ||
                user.PhoneNo == txtSearch
                );

    }
}
