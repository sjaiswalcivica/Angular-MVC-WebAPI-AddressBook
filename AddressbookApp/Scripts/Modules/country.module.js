"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var country_component_1 = require("./../Components/country.component");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var country_routing_1 = require("./../Routings/country.routing");
var common_1 = require("@angular/common");
var country_pipe_1 = require("./../Pipes/country.pipe");
var ng2_pagination_1 = require("ng2-pagination");
var orderfilter_module_1 = require("./../Modules/orderfilter.module");
var CountryModule = /** @class */ (function () {
    function CountryModule() {
    }
    CountryModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule, http_1.HttpModule, forms_1.FormsModule, country_routing_1.routing, ng2_pagination_1.Ng2PaginationModule, orderfilter_module_1.OrderFilterModule],
            declarations: [country_component_1.CountryComponent, country_pipe_1.CountryFilter],
            bootstrap: [country_component_1.CountryComponent],
            entryComponents: []
        })
    ], CountryModule);
    return CountryModule;
}());
exports.CountryModule = CountryModule;
//# sourceMappingURL=country.module.js.map