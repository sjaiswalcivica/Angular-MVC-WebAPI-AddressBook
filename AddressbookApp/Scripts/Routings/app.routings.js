"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var user_component_1 = require("./../Components/user.component");
var admin_component_1 = require("./../Components/admin.component");
var routes = [
    { path: 'countries', loadChildren: '/Scripts/Modules/country.module#CountryModule' },
    { path: 'countries/:id', loadChildren: '/Scripts/Modules/country.module#CountryModule' },
    { path: 'states', loadChildren: '/Scripts/Modules/state.module#StateModule' },
    { path: 'states/:id', loadChildren: '/Scripts/Modules/state.module#StateModule' },
    { path: 'addresses', loadChildren: '/Scripts/Modules/addressbook.module#AddressbookModule' },
    { path: 'addresses/:id', loadChildren: '/Scripts/Modules/addressbook.module#AddressbookModule' },
    { path: 'users', loadChildren: '/Scripts/Modules/userdetail.module#UserdetailModule' },
    { path: 'users/:id', loadChildren: '/Scripts/Modules/userdetail.module#UserdetailModule' },
    { path: 'logout/user/:id', component: user_component_1.UserComponent },
    { path: 'logout/admin/:id', component: admin_component_1.AdminComponent }
];
exports.routings = router_1.RouterModule.forRoot(routes);
//# sourceMappingURL=app.routings.js.map