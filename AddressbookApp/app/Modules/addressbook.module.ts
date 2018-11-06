import { NgModule } from '@angular/core';
import { AddressbookComponent } from './../Components/addressbook.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { routings } from './../Routings/addressbook.routing';
import { CommonModule } from '@angular/common';
import { AddressFilter } from './../Pipes/address.pipe';
import { Ng2PaginationModule } from 'ng2-pagination';
import { OrderFilterModule } from './../Modules/orderfilter.module';

@NgModule({
    imports: [CommonModule, HttpModule, FormsModule, routings, Ng2PaginationModule,OrderFilterModule],
    declarations: [AddressbookComponent, AddressFilter],
    bootstrap: [AddressbookComponent]
})
export class AddressbookModule { }



