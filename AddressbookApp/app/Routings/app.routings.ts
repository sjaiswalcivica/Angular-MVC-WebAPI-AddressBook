import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { UserComponent } from './../Components/user.component';
import { AdminComponent } from './../Components/admin.component';
import { LoginComponent } from './../Components/LoginComponent';

var routes: Routes = [   
    { path: 'countries', loadChildren: '/Scripts/Modules/country.module#CountryModule' },
    { path: 'countries/:id', loadChildren: '/Scripts/Modules/country.module#CountryModule' },
    { path: 'states', loadChildren: '/Scripts/Modules/state.module#StateModule' },
    { path: 'states/:id', loadChildren: '/Scripts/Modules/state.module#StateModule' },
    { path: 'addresses', loadChildren: '/Scripts/Modules/addressbook.module#AddressbookModule' },
    { path: 'addresses/:id', loadChildren: '/Scripts/Modules/addressbook.module#AddressbookModule' },
    { path: 'users', loadChildren: '/Scripts/Modules/userdetail.module#UserdetailModule' },
    { path: 'users/:id', loadChildren: '/Scripts/Modules/userdetail.module#UserdetailModule' },
    { path: 'logout/user/:id', component: UserComponent },
    { path: 'logout/admin/:id', component: AdminComponent }
];

export const routings: ModuleWithProviders = RouterModule.forRoot(routes);