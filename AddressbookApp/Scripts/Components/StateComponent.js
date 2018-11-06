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
var router_1 = require("@angular/router");
var StateService_1 = require("./../Services/StateService");
var CountryService_1 = require("./../Services/CountryService");
var app_models_1 = require("./../app.models");
var StateComponent = (function () {
    function StateComponent(service, countryService, route) {
        var _this = this;
        this.service = service;
        this.countryService = countryService;
        this.route = route;
        this.state = new app_models_1.State();
        this.action = "Add";
        this.isDesc = false;
        this.column = 'StateName';
        this.GetAllStates();
        this.GetAllCountries();
        this.route.params.subscribe(function (params) {
            _this.GetState(params["id"]);
            _this.action = "Edit";
        });
    }
    StateComponent.prototype.GetAllStates = function () {
        var _this = this;
        this.service.GetAll().subscribe(function (states) { return _this.states = states; });
    };
    StateComponent.prototype.GetAllCountries = function () {
        var _this = this;
        this.countryService.GetAll().subscribe(function (countries) { return _this.countries = countries; });
    };
    StateComponent.prototype.GetState = function (id) {
        var _this = this;
        if (id !== undefined)
            this.service.Get(id).subscribe(function (state) { return _this.state = state; });
    };
    StateComponent.prototype.AddState = function () {
        var _this = this;
        this.service.Add(this.state).subscribe(function (states) { return _this.states = states; });
    };
    StateComponent.prototype.EditState = function () {
        var _this = this;
        console.log(this.state);
        this.service.Edit(this.state).subscribe(function (states) { return _this.states = states; });
    };
    StateComponent.prototype.DeleteState = function (stateId) {
        var _this = this;
        this.service.Delete(stateId).subscribe(function (states) { return _this.states = states; });
    };
    StateComponent.prototype.reset = function (addEditForm) {
        this.action = "Add";
        this.addEditForm.reset();
    };
    StateComponent.prototype.sortby = function (property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        this.direction = this.isDesc ? 1 : -1;
    };
    ;
    return StateComponent;
}());
__decorate([
    core_1.ViewChild('addEditForm'),
    __metadata("design:type", Object)
], StateComponent.prototype, "addEditForm", void 0);
StateComponent = __decorate([
    core_1.Component({
        templateUrl: './../../app/Views/State/index.html',
        providers: [StateService_1.StateService, CountryService_1.CountryService]
    }),
    __metadata("design:paramtypes", [StateService_1.StateService, CountryService_1.CountryService, router_1.ActivatedRoute])
], StateComponent);
exports.StateComponent = StateComponent;
//# sourceMappingURL=StateComponent.js.map