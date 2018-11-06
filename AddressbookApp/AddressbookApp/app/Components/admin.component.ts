import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from './../Services/UserService';   

@Component({
    selector: 'admin',
    providers: [UserService],
    templateUrl: `./../../app/Views/Shared/adminlayout.html`
})
export class AdminComponent {
    errorMessage: string;
    constructor(private userService: UserService, private route: ActivatedRoute) {
        //console.log(this.route);
        this.route.params.subscribe(params => {
            console.log(params["id"]);
            if (params["id"] == "1")
                this.logout();
        },
            error => this.errorMessage = <any>error
        );
    }

    logout() {
        this.userService.Logout().subscribe();
        location.href = "/home/index";
    }
}
