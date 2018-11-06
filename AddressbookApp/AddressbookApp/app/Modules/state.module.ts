import { NgModule } from '@angular/core';
import { StateComponent } from './../Components/state.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { routing } from './../Routings/state.routings';
import { CommonModule } from '@angular/common';
import { StateFilter } from './../Pipes/state.pipe';
import { Ng2PaginationModule } from 'ng2-pagination';
import { OrderFilterModule } from './../Modules/orderfilter.module';

@NgModule({
    imports: [CommonModule, HttpModule, FormsModule, routing, Ng2PaginationModule, OrderFilterModule],
    declarations: [StateComponent, StateFilter],
    bootstrap: [StateComponent]
})
export class StateModule {}



