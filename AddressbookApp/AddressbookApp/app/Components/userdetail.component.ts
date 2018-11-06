import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Userdetail } from './../app.models';
import { UserService } from './../Services/UserService';

@Component({
    templateUrl: './../../app/Views/Userdetail/index.html',
    providers: [UserService]
})
export class UserdetailComponent {
    @ViewChild('addEditForm') addEditForm: any;
    users: Userdetail[];
    user: Userdetail = new Userdetail();
    errorMessage: string;
    action: any;
    isDesc: boolean = false;
    column: string = 'UserName';
    direction: number;

    constructor(private service: UserService, private route: ActivatedRoute) {
        this.route.params.subscribe(params => {
            this.GetUser(params["id"]);
            
            this.action = "Edit";
        });
        this.GetAllUsers();
    }
    GetAllUsers() {
        this.service.GetAll().subscribe(
            users => this.users = users,
            error => this.errorMessage = <any>error
        );
    }
    GetUser(id: any) {
        if (id !== undefined)
            this.service.Get(id).subscribe(
                user => this.user = user,
                error => this.errorMessage = <any>error
            );
    }
    AddUser() {
        this.service.Add(this.user).subscribe(
            users => this.users = users,
            error => this.errorMessage = <any>error
        );
    }
    EditUser() {
        this.service.Edit(this.user).subscribe(
            users => this.users = users,
            error => this.errorMessage = <any>error
        );
    }
    DeleteUser(userId: any) {
        this.service.Delete(userId).subscribe(
            users => this.users = users,
            error => this.errorMessage = <any>error
        );
    }
    reset(addEditForm: any) {
        this.action = "Add";
        this.addEditForm.reset();
    }   
    sortby(property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        this.direction = this.isDesc ? 1 : -1;
    };
}