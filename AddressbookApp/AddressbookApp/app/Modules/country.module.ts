import { NgModule } from '@angular/core';
import { CountryComponent } from './../Components/country.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { routing } from './../Routings/country.routing';
import { CommonModule } from '@angular/common';
import { CountryFilter } from './../Pipes/country.pipe';
import { Ng2PaginationModule } from 'ng2-pagination';
import { OrderFilterModule } from './../Modules/orderfilter.module';

@NgModule({
    imports: [CommonModule, HttpModule, FormsModule, routing, Ng2PaginationModule, OrderFilterModule],
    declarations: [CountryComponent, CountryFilter],
    bootstrap: [CountryComponent],
    entryComponents:[]
})
export class CountryModule { }



