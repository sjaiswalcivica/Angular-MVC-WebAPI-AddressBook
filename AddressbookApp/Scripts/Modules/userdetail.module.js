"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var userdetail_component_1 = require("./../Components/userdetail.component");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var userdetail_routing_1 = require("./../Routings/userdetail.routing");
var common_1 = require("@angular/common");
var userdetail_pipe_1 = require("./../Pipes/userdetail.pipe");
var ng2_pagination_1 = require("ng2-pagination");
var orderfilter_module_1 = require("./../Modules/orderfilter.module");
var UserdetailModule = /** @class */ (function () {
    function UserdetailModule() {
    }
    UserdetailModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule, http_1.HttpModule, forms_1.FormsModule, userdetail_routing_1.routings, ng2_pagination_1.Ng2PaginationModule, orderfilter_module_1.OrderFilterModule],
            declarations: [userdetail_component_1.UserdetailComponent, userdetail_pipe_1.UserDetailFilter],
            bootstrap: [userdetail_component_1.UserdetailComponent]
        })
    ], UserdetailModule);
    return UserdetailModule;
}());
exports.UserdetailModule = UserdetailModule;
//# sourceMappingURL=userdetail.module.js.map