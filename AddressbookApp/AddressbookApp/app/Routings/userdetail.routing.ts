import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { UserdetailComponent } from './../Components/userdetail.component';

const routes: Routes = [
    { path: '', component: UserdetailComponent }
]

export const routings: ModuleWithProviders = RouterModule.forChild(routes);
