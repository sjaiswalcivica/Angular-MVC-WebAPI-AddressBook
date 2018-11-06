"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var state_component_1 = require("./../Components/state.component");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var state_routings_1 = require("./../Routings/state.routings");
var common_1 = require("@angular/common");
var state_pipe_1 = require("./../Pipes/state.pipe");
var ng2_pagination_1 = require("ng2-pagination");
var orderfilter_module_1 = require("./../Modules/orderfilter.module");
var StateModule = /** @class */ (function () {
    function StateModule() {
    }
    StateModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule, http_1.HttpModule, forms_1.FormsModule, state_routings_1.routing, ng2_pagination_1.Ng2PaginationModule, orderfilter_module_1.OrderFilterModule],
            declarations: [state_component_1.StateComponent, state_pipe_1.StateFilter],
            bootstrap: [state_component_1.StateComponent]
        })
    ], StateModule);
    return StateModule;
}());
exports.StateModule = StateModule;
//# sourceMappingURL=state.module.js.map