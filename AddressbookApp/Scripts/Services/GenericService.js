"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/http");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var observable_1 = require("rxjs/observable");
var GenericService = /** @class */ (function () {
    function GenericService(http, url) {
        this.http = http;
        this.url = url;
    }
    GenericService.prototype.GetAll = function () {
        return this.http.get(this.url)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    GenericService.prototype.Get = function (id) {
        var url = this.url + "/" + id;
        return this.http.get(url)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    GenericService.prototype.Add = function (entity) {
        var data = JSON.stringify(entity);
        var headers = new http_1.Headers({ "content-type": "application/json" });
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.post(this.url, data, options)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    GenericService.prototype.Edit = function (entity) {
        var data = JSON.stringify(entity);
        console.log(entity);
        var headers = new http_1.Headers({ "content-type": "application/json" });
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.put(this.url, data, options)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    GenericService.prototype.Delete = function (id) {
        var url = this.url + "/" + id;
        return this.http.delete(url)
            .map(function (res) { return res.json(); })
            .catch(this.handleError);
    };
    GenericService.prototype.handleError = function (error) {
        var errMsg;
        if (error instanceof http_1.Response) {
            var body = error.json() || '';
            var err = body.error || JSON.stringify(body);
            errMsg = error.status + " - " + (error.statusText || '') + " " + err;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return observable_1.Observable.throw(errMsg);
    };
    return GenericService;
}());
exports.GenericService = GenericService;
//# sourceMappingURL=GenericService.js.map