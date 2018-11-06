"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var GenericService_1 = require("./GenericService");
var http_1 = require("@angular/http");
var UserService = /** @class */ (function (_super) {
    __extends(UserService, _super);
    function UserService(http) {
        return _super.call(this, http, "/api/UserDetailsAPI") || this;
    }
    UserService.prototype.GetLoginUser = function () {
        return this.http.get('/api/UserDetailsAPI/GetLoginUser')
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UserService.prototype.Logout = function () {
        var data = {};
        var headers = new http_1.Headers({ "content-type": "application/json" });
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.post('/Login/LogOff', data, options)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    UserService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], UserService);
    return UserService;
}(GenericService_1.GenericService));
exports.UserService = UserService;
//# sourceMappingURL=UserService.js.map