"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var AddressFilter = /** @class */ (function () {
    function AddressFilter() {
    }
    AddressFilter.prototype.transform = function (addresses, txtSearch) {
        if (txtSearch == null)
            return addresses;
        else
            return addresses.filter(function (address) {
                return address.FirstName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                    address.LastName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                    address.EmailId.toLowerCase().includes(txtSearch.toLowerCase()) ||
                    address.Userdetail.UserName.toLowerCase().includes(txtSearch.toLowerCase()) ||
                    address.Street.toLowerCase().includes(txtSearch.toLowerCase()) ||
                    address.City.toLowerCase().includes(txtSearch.toLowerCase()) ||
                    address.State.StateName.toLowerCase().includes(txtSearch.toLowerCase());
            });
    };
    AddressFilter = __decorate([
        core_1.Pipe({ name: "addressfilter" })
    ], AddressFilter);
    return AddressFilter;
}());
exports.AddressFilter = AddressFilter;
//# sourceMappingURL=address.pipe.js.map