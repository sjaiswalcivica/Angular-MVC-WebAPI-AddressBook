import { Component } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { LoginModel } from './../app.models';
import { AuthenticateService } from './../Services/AuthenticateService';

@Component({
    selector:'my-app',
    templateUrl: './../../Views/Login/index.html',
    providers: [AuthenticateService]
})
export class LoginComponent {
    login: LoginModel = new LoginModel();
    isLogin: boolean = false;
    message: string;
    constructor(private service: AuthenticateService,private router:Router) {}

    AuthenticateUser() {
        this.service.AuthenticateUser(this.login).subscribe(loginModel => {
            console.log(loginModel);
            this.login = loginModel            
            if (this.login.UserName != "admin") {
                this.router.navigate(['authuser']);
                localStorage.setItem("role", "user");
            }
            else if (this.login.UserName == "admin") {
                this.router.navigate(['admin']);
                localStorage.setItem("role", "admin");
            }
            else {
                this.message = "username and password doesn't match";
                localStorage.setItem("role", "guest");
            }
        });
        
    }
}
