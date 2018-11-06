import { Pipe, PipeTransform } from '@angular/core';
import { Country } from './../app.models';

@Pipe({ name: "countriesfilter" })
export class CountryFilter implements PipeTransform {

    transform(countries: Country[], txtSearch: string) {
        
        if (txtSearch == null || txtSearch == "" || txtSearch == undefined)
            return countries;
        else
            return countries.filter(country => country.CountryName.toLowerCase().includes(txtSearch.toLowerCase()));
        
    }
}
