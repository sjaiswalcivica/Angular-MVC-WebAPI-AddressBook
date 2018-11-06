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
var AuthenticateService_1 = require("./../Services/AuthenticateService");
var LoginComponent = /** @class */ (function () {
    function LoginComponent(service, router) {
        this.service = service;
        this.router = router;
        this.login = new app_models_1.LoginModel();
        this.isLogin = false;
    }
    LoginComponent.prototype.AuthenticateUser = function () {
        var _this = this;
        this.service.AuthenticateUser(this.login).subscribe(function (loginModel) {
            console.log(loginModel);
            _this.login = loginModel;
            if (_this.login.UserName != "admin") {
                _this.router.navigate(['authuser']);
                localStorage.setItem("role", "user");
            }
            else if (_this.login.UserName == "admin") {
                _this.router.navigate(['admin']);
                localStorage.setItem("role", "admin");
            }
            else {
                _this.message = "username and password doesn't match";
                localStorage.setItem("role", "guest");
            }
        });
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: './../../Views/Login/index.html',
            providers: [AuthenticateService_1.AuthenticateService]
        }),
        __metadata("design:paramtypes", [AuthenticateService_1.AuthenticateService, router_1.Router])
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=LoginComponent.js.map