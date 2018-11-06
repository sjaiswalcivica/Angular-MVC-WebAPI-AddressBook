"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var app_models_1 = require("./../app.models");
var CountryService_1 = require("./../Services/CountryService");
var router_1 = require("@angular/router");
var CountryComponent = (function () {
    function CountryComponent(service, route) {
        var _this = this;
        this.service = service;
        this.route = route;
        this.country = new app_models_1.Country();
        this.action = "Add";
        this.isDesc = false;
        this.column = 'CountryName';
        this.GetAllCountries();
        this.route.params.subscribe(function (params) {
            _this.GetCountry(params["id"]);
            _this.action = "Edit";
        });
    }
    CountryComponent.prototype.GetAllCountries = function () {
        var _this = this;
        this.service.GetAll().subscribe(function (countries) { return _this.countries = countries; });
    };
    CountryComponent.prototype.GetCountry = function (id) {
        var _this = this;
        if (id !== undefined)
            this.service.Get(id).subscribe(function (country) { return _this.country = country; });
    };
    CountryComponent.prototype.AddCountry = function () {
        var _this = this;
        this.service.Add(this.country).subscribe(function (countries) { return _this.countries = countries; });
    };
    CountryComponent.prototype.EditCountry = function () {
        var _this = this;
        this.service.Edit(this.country).subscribe(function (countries) { return _this.countries = countries; });
    };
    CountryComponent.prototype.DeleteCountry = function (countryId) {
        var _this = this;
        this.service.Delete(countryId).subscribe(function (countries) { return _this.countries = countries; });
    };
    CountryComponent.prototype.reset = function (addEditForm) {
        this.action = "Add";
        this.addEditForm.reset();
    };
    CountryComponent.prototype.sortby = function (property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        this.direction = this.isDesc ? 1 : -1;
    };
    ;
    return CountryComponent;
}());
__decorate([
    core_1.ViewChild('addEditForm'),
    __metadata("design:type", Object)
], CountryComponent.prototype, "addEditForm", void 0);
CountryComponent = __decorate([
    core_1.Component({
        templateUrl: '/app/Views/Country/index.html',
        providers: [CountryService_1.CountryService]
    }),
    __metadata("design:paramtypes", [CountryService_1.CountryService, router_1.ActivatedRoute])
], CountryComponent);
exports.CountryComponent = CountryComponent;
//# sourceMappingURL=CountryComponent.js.map