import { Pipe, PipeTransform } from '@angular/core';
import { State } from './../app.models';

@Pipe({ name: "statefilter" })
export class StateFilter implements PipeTransform {

    transform(states: State[], txtSearch: any) {
        if (txtSearch == null || txtSearch == "" || txtSearch == undefined)
            return states;
        else
            return states.filter(state =>
                state.StateName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                state.Country.CountryName.toLowerCase().includes(txtSearch.toLowerCase())
            );
    }
}
