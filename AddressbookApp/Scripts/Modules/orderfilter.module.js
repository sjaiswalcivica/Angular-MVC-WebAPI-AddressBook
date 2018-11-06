"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var order_pipe_1 = require("./../Pipes/order.pipe");
var common_1 = require("@angular/common");
var OrderFilterModule = /** @class */ (function () {
    function OrderFilterModule() {
    }
    OrderFilterModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule],
            declarations: [order_pipe_1.OrderrByPipe],
            exports: [order_pipe_1.OrderrByPipe],
        })
    ], OrderFilterModule);
    return OrderFilterModule;
}());
exports.OrderFilterModule = OrderFilterModule;
//# sourceMappingURL=orderfilter.module.js.map