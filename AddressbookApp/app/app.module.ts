import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';  //importing app.component module
import { LoginComponent } from './Components/LoginComponent';
import { UserComponent } from './Components/user.component';
import { AdminComponent } from './Components/admin.component';
import { routings } from './Routings/app.routings';

@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule, routings],
    declarations: [AppComponent, UserComponent, AdminComponent],
    bootstrap: [AppComponent]
})
export class AppModule {  }
