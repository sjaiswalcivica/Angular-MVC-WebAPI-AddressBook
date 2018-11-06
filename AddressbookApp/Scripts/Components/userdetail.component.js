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
var UserService_1 = require("./../Services/UserService");
var UserdetailComponent = /** @class */ (function () {
    function UserdetailComponent(service, route) {
        var _this = this;
        this.service = service;
        this.route = route;
        this.user = new app_models_1.Userdetail();
        this.isDesc = false;
        this.column = 'UserName';
        this.route.params.subscribe(function (params) {
            _this.GetUser(params["id"]);
            _this.action = "Edit";
        });
        this.GetAllUsers();
    }
    UserdetailComponent.prototype.GetAllUsers = function () {
        var _this = this;
        this.service.GetAll().subscribe(function (users) { return _this.users = users; }, function (error) { return _this.errorMessage = error; });
    };
    UserdetailComponent.prototype.GetUser = function (id) {
        var _this = this;
        if (id !== undefined)
            this.service.Get(id).subscribe(function (user) { return _this.user = user; }, function (error) { return _this.errorMessage = error; });
    };
    UserdetailComponent.prototype.AddUser = function () {
        var _this = this;
        this.service.Add(this.user).subscribe(function (users) { return _this.users = users; }, function (error) { return _this.errorMessage = error; });
    };
    UserdetailComponent.prototype.EditUser = function () {
        var _this = this;
        this.service.Edit(this.user).subscribe(function (users) { return _this.users = users; }, function (error) { return _this.errorMessage = error; });
    };
    UserdetailComponent.prototype.DeleteUser = function (userId) {
        var _this = this;
        this.service.Delete(userId).subscribe(function (users) { return _this.users = users; }, function (error) { return _this.errorMessage = error; });
    };
    UserdetailComponent.prototype.reset = function (addEditForm) {
        this.action = "Add";
        this.addEditForm.reset();
    };
    UserdetailComponent.prototype.sortby = function (property) {
        this.isDesc = !this.isDesc; //change the direction    
        this.column = property;
        this.direction = this.isDesc ? 1 : -1;
    };
    ;
    __decorate([
        core_1.ViewChild('addEditForm'),
        __metadata("design:type", Object)
    ], UserdetailComponent.prototype, "addEditForm", void 0);
    UserdetailComponent = __decorate([
        core_1.Component({
            templateUrl: './../../app/Views/Userdetail/index.html',
            providers: [UserService_1.UserService]
        }),
        __metadata("design:paramtypes", [UserService_1.UserService, router_1.ActivatedRoute])
    ], UserdetailComponent);
    return UserdetailComponent;
}());
exports.UserdetailComponent = UserdetailComponent;
//# sourceMappingURL=userdetail.component.js.map