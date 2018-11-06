import { Routes,RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { StateComponent } from './../Components/state.component';
const routes: Routes = [
    { path: '', component: StateComponent },    
];
export const routing: ModuleWithProviders= RouterModule.forChild(routes);