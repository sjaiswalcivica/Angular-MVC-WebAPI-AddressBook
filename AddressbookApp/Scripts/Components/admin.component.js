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
var UserService_1 = require("./../Services/UserService");
var AdminComponent = /** @class */ (function () {
    function AdminComponent(userService, route) {
        var _this = this;
        this.userService = userService;
        this.route = route;
        console.log(this.route);
        this.route.params.subscribe(function (params) {
            console.log(params["id"]);
            if (params["id"] == "1")
                _this.logout();
        }, function (error) { return _this.errorMessage = error; });
    }
    AdminComponent.prototype.logout = function () {
        this.userService.Logout().subscribe();
        location.href = "/home/index";
    };
    AdminComponent = __decorate([
        core_1.Component({
            selector: 'admin',
            providers: [UserService_1.UserService],
            templateUrl: "./../../app/Views/Shared/adminlayout.html"
        }),
        __metadata("design:paramtypes", [UserService_1.UserService, router_1.ActivatedRoute])
    ], AdminComponent);
    return AdminComponent;
}());
exports.AdminComponent = AdminComponent;
//# sourceMappingURL=admin.component.js.map