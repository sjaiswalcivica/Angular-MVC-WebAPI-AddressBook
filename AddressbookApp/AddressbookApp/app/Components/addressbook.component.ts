import { Component, ViewChild, Pipe } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Addressbook, State, Userdetail } from './../app.models';
import { StateService } from './../Services/StateService';
import { AddressbookService } from './../Services/AddressbookService';
import { UserService } from './../Services/UserService';

@Component({
    templateUrl: './../../app/Views/Addressbook/index.html',
    providers: [AddressbookService, StateService, UserService],
})
export class AddressbookComponent {
    @ViewChild('addEditForm') addEditForm: any;
    errorMessage: string;
    addresses: Addressbook[];
    states: State[];
    address: Addressbook = new Addressbook();
    filteredAddresses: Addressbook[];
    user: Userdetail = new Userdetail();
    role: string;
    action: any;
    txtsearch: string;
    isDesc: boolean = false;
    column: string = 'FirstName';
    direction: number;

    constructor(private service: AddressbookService, private stateService: StateService, private userService: UserService, private route: ActivatedRoute) {
        this.route.params.subscribe(params => {
            this.GetAddress(params["id"]);
            this.action = "Edit"
        });
        this.GetAllAddresses();
        this.GetAllStates();
    }

    GetAllAddresses() {
        this.service.GetAll().subscribe(addresses => {
            this.addresses = addresses;
            this.role = "admin";
            this.filteredAddresses = this.addresses;
            this.GetFilteredAddresses();
        });
    }
    GetFilteredAddresses() {
        this.userService.GetLoginUser().subscribe(user => {
            this.user = user;
            if (this.user != null) {
                this.filteredAddresses = this.addresses.filter(address => address.FKUserId == this.user.PKUserId);
                this.role = "user";
            }
        },
            error => this.errorMessage = <any>error
        );
    }
    GetAllStates() {
        this.stateService.GetAll().subscribe(
            states => this.states = states,
            error => this.errorMessage = <any>error
        );
    }
    GetAddress(id: any) {
        if (id !== undefined)
            this.service.Get(id).subscribe(
                address => this.address = address,
                error => this.errorMessage = <any>error
            );
    }
    AddAddress() {
        this.service.Add(this.address).subscribe(
            addresses => { this.addresses = addresses; this.GetFilteredAddresses(); },
            error => this.errorMessage = <any>error
        );
    }
    EditAddress() {
        this.service.Edit(this.address).subscribe(
            addresses => { this.addresses = addresses; this.GetFilteredAddresses(); },
            error => this.errorMessage = <any>error
        );
    }
    DeleteAddress(addressId: any) {
        this.service.Delete(addressId).subscribe(
            addresses => { this.addresses = addresses; this.GetFilteredAddresses(); },
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