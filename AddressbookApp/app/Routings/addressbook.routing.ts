import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { AddressbookComponent } from './../Components/addressbook.component';

const routes: Routes = [
    { path: '', component: AddressbookComponent }
]

export const routings: ModuleWithProviders = RouterModule.forChild(routes);
