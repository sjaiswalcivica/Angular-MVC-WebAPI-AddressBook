import { Component,ViewChild} from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Country } from './../app.models';
import { CountryService } from './../Services/CountryService';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: '/app/Views/Country/index.html',
    providers: [CountryService]
})

export class CountryComponent {
    countries: Country[];
    country: Country = new Country();
    action: string = "Add";
    URL: string;
    errorMessage: string;
    @ViewChild('addEditForm') addEditForm: any;

    txtsearch: string;
    isDesc: boolean = false;
    column: string = 'CountryName';
    direction: number;

    constructor(private service: CountryService, private route: ActivatedRoute) {
        this.GetAllCountries();
        this.route.params.subscribe(params => {
            this.GetCountry(params["id"]);
            this.action = "Edit"
        });
    }
    

    GetAllCountries() {
        this.service.GetAll().subscribe(
            countries => this.countries = countries,
            error => this.errorMessage = <any>error
        );
    }
    GetCountry(id: any) {
        if (id !== undefined)
            this.service.Get(id).subscribe(
                country => this.country = country,
                error => this.errorMessage = <any>error
            );
    }
    AddCountry() {
        this.service.Add(this.country).subscribe(
            countries => this.countries = countries,
            error => this.errorMessage = <any>error
        );
    }
    EditCountry() {
        this.service.Edit(this.country).subscribe(
            countries => this.countries = countries,
            error => this.errorMessage = <any>error
        );
    }
    DeleteCountry(countryId: any) {
        this.service.Delete(countryId).subscribe(
            countries => this.countries = countries,
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

