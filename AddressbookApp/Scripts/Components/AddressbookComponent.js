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
var app_models_1 = require("./../app.models");
var StateService_1 = require("./../Services/StateService");
var AddressbookService_1 = require("./../Services/AddressbookService");
var UserService_1 = require("./../Services/UserService");
var AddressbookComponent = (function () {
    function AddressbookComponent(service, stateService, userService, route) {
        var _this = this;
        this.service = service;
        this.stateService = stateService;
        this.userService = userService;
        this.route = route;
        this.address = new app_models_1.Addressbook();
        this.user = new app_models_1.Userdetail();
        this.isDesc = false;
        this.column = 'FirstName';
        this.route.params.subscribe(function (params) {
            _this.GetAddress(params["id"]);
            _this.action = "Edit";
        });
        this.GetAllAddresses();
        this.GetAllStates();
    }
    AddressbookComponent.prototype.GetAllAddresses = function () {
        var _this = this;
        this.service.GetAll().subscribe(function (addresses) {
            _this.addresses = addresses;
            _this.role = "admin";
            _this.filteredAddresses = _this.addresses;
            _this.GetFilteredAddresses();
        });
    };
    AddressbookComponent.prototype.GetFilteredAddresses = function () {
        var _this = this;
        this.userService.GetLoginUser().subscribe(function (user) {
            _this.user = user;
            if (_this.user != null) {
                _this.filteredAddresses = _this.addresses.filter(function (address) { return address.FKUserId == _this.user.PKUserId; });
                _this.role = "user";
            }
        });
    };
    AddressbookComponent.prototype.GetAllStates = function () {
        var _this = this;
        this.stateService.GetAll().subscribe(function (states) { return _this.states = states; });
    };
    AddressbookComponent.prototype.GetAddress = function (id) {
        var _this = this;
        if (id !== undefined)
            this.service.Get(id).subscribe(function (address) { return _this.address = address; });
    };
    AddressbookComponent.prototype.AddAddress = function () {
        var _this = this;
        this.service.Add(this.address).subscribe(function (addresses) { _this.addresses = addresses; _this.GetFilteredAddresses(); });
    };
    AddressbookComponent.prototype.EditAddress = function () {
        var _this = this;
        this.service.Edit(this.address).subscribe(function (addresses) { _this.addresses = addresses; _this.GetFilteredAddresses(); });
    };
    AddressbookComponent.prototype.DeleteAddress = function (addressId) {
        var _this = this;
        this.service.Delete(addressId).subscribe(function (addresses) { _this.addresses = addresses; _this.GetFilteredAddresses(); });
    };
    AddressbookComponent.prototype.reset = function (addEditForm) {
        this.action = "Add";
        this.addEditForm.reset();
    };
    AddressbookComponent.prototype.sortby = function (property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        this.direction = this.isDesc ? 1 : -1;
    };
    ;
    return AddressbookComponent;
}());
__decorate([
    core_1.ViewChild('addEditForm'),
    __metadata("design:type", Object)
], AddressbookComponent.prototype, "addEditForm", void 0);
AddressbookComponent = __decorate([
    core_1.Component({
        templateUrl: './../../app/Views/Addressbook/index.html',
        providers: [AddressbookService_1.AddressbookService, StateService_1.StateService, UserService_1.UserService],
    }),
    __metadata("design:paramtypes", [AddressbookService_1.AddressbookService, StateService_1.StateService, UserService_1.UserService, router_1.ActivatedRoute])
], AddressbookComponent);
exports.AddressbookComponent = AddressbookComponent;
//# sourceMappingURL=AddressbookComponent.js.map