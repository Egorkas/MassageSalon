var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
let MasseurService = class MasseurService {
    constructor(http) {
        this.http = http;
        this.accessPointUrl = 'https://localhost:44379/api/masseurs';
        this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    }
    get() {
        return this.http.get(this.accessPointUrl, { headers: this.headers });
    }
};
MasseurService = __decorate([
    Injectable()
], MasseurService);
export { MasseurService };
//# sourceMappingURL=masseur.service.js.map