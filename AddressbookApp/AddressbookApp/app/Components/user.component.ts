import { Component } from '@angular/core';
import { UserService } from './../Services/UserService';
import { ActivatedRoute } from '@angular/router';
import { Userdetail } from './../app.models';

@Component({
    selector: 'user',
    providers: [UserService],
    templateUrl: `./../../app/Views/Shared/userlayout.html`
})
export class UserComponent {
    errorMessage: string;
    user: Userdetail = new Userdetail();
    constructor(private userService: UserService, private route: ActivatedRoute) {
        this.route.params.subscribe(params => { if (params["id"] == "1") this.logout(); });
        this.GetLoginUser();
    }
    GetLoginUser() {
        this.userService.GetLoginUser().subscribe(
            user => this.user = user,
            error => this.errorMessage = <any>error
        );
    }
    logout() {
        this.userService.Logout().subscribe();
        location.href = "/home/index";
    }
}
