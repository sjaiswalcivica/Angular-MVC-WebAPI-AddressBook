import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { UserComponent } from './../Components/user.component';
import { AdminComponent } from './../Components/admin.component';
import { routings } from './../Routings/app.routings';


@NgModule({
    imports: [BrowserModule, CommonModule, HttpModule, FormsModule, routings],
    declarations: [UserComponent, AdminComponent],
    bootstrap: [UserComponent]
})
export class AppModule { }
