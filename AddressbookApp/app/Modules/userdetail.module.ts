import { NgModule } from '@angular/core';
import { UserdetailComponent } from './../Components/userdetail.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { routings } from './../Routings/userdetail.routing';
import { CommonModule } from '@angular/common';
import { UserDetailFilter } from './../Pipes/userdetail.pipe';
import { Ng2PaginationModule } from 'ng2-pagination';
import { OrderFilterModule } from './../Modules/orderfilter.module';

@NgModule({
    imports: [CommonModule, HttpModule, FormsModule, routings, Ng2PaginationModule,OrderFilterModule],
    declarations: [UserdetailComponent, UserDetailFilter],
    bootstrap: [UserdetailComponent]
})
export class UserdetailModule { }



