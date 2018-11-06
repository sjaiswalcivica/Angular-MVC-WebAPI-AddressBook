import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { CountryComponent } from './../Components/country.component';
const routes: Routes = [
    { path: '', component: CountryComponent },
];
export const routing: ModuleWithProviders = RouterModule.forChild(routes);