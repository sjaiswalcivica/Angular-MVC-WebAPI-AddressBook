import { Component,ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StateService } from './../Services/StateService';
import { CountryService } from './../Services/CountryService';
import { State, Country } from './../app.models';

@Component({
    templateUrl: './../../app/Views/State/index.html',
    providers: [StateService, CountryService]
})
export class StateComponent {
    constructor(private service: StateService, private countryService: CountryService, private route: ActivatedRoute) {
        this.GetAllStates();
        this.GetAllCountries();
        this.route.params.subscribe(params => {
            this.GetState(params["id"]);
            this.action = "Edit"
        });
    }
    states: State[];
    countries: Country[];
    state: State = new State();
    action: string = "Add";
    URL: string;
    errorMessage: string;
    @ViewChild('addEditForm') addEditForm: any;
    isDesc: boolean = false;
    column: string = 'StateName';
    direction: number;


    GetAllStates() {
        this.service.GetAll().subscribe(
            states => this.states = states,
            error => this.errorMessage = <any>error
        );
    }
    GetAllCountries() {
        this.countryService.GetAll().subscribe(
            countries => this.countries = countries,
            error => this.errorMessage = <any>error
        );
    }
    GetState(id: any) {
        if (id !== undefined)
            this.service.Get(id).subscribe(
                state => this.state = state,
                error => this.errorMessage = <any>error
            );
    }
    AddState() {
        this.service.Add(this.state).subscribe(
            states => this.states = states,
            error => this.errorMessage = <any>error
        );
    }
    EditState() {
        console.log(this.state);
        this.service.Edit(this.state).subscribe(
            states => this.states = states,
            error => this.errorMessage = <any>error
        );
    }
    DeleteState(stateId: any) {
        this.service.Delete(stateId).subscribe(
            states => this.states = states,
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