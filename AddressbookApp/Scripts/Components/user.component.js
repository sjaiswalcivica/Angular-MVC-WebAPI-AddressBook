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
var UserService_1 = require("./../Services/UserService");
var router_1 = require("@angular/router");
var app_models_1 = require("./../app.models");
var UserComponent = /** @class */ (function () {
    function UserComponent(userService, route) {
        var _this = this;
        this.userService = userService;
        this.route = route;
        this.user = new app_models_1.Userdetail();
        this.route.params.subscribe(function (params) { if (params["id"] == "1")
            _this.logout(); });
        this.GetLoginUser();
    }
    UserComponent.prototype.GetLoginUser = function () {
        var _this = this;
        this.userService.GetLoginUser().subscribe(function (user) { return _this.user = user; }, function (error) { return _this.errorMessage = error; });
    };
    UserComponent.prototype.logout = function () {
        this.userService.Logout().subscribe();
        location.href = "/home/index";
    };
    UserComponent = __decorate([
        core_1.Component({
            selector: 'user',
            providers: [UserService_1.UserService],
            templateUrl: "./../../app/Views/Shared/userlayout.html"
        }),
        __metadata("design:paramtypes", [UserService_1.UserService, router_1.ActivatedRoute])
    ], UserComponent);
    return UserComponent;
}());
exports.UserComponent = UserComponent;
//# sourceMappingURL=user.component.js.map