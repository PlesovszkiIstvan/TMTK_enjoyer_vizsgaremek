// login.component.ts
import { Component, OnInit } from '@angular/core';
import { UserAuthService } from '../user-auth.service';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: string = '';
  password: string = '';
  userName: string = '';
  firstName: string = '';
  lastName: string = '';
  isSubmitting: boolean = false;
  validationErrors: any = [];

  constructor(public userAuthService: UserAuthService, private router: Router, public appcomponent: AppComponent) { }

  ngOnInit(): void {

  }

  loginAction() {
    this.isSubmitting = true;
    let payload = {
      email: this.email,
      password: this.password
    };

    this.userAuthService.login(payload).subscribe((res)=>{
      if(res.success==true){
        alert("Sikeres bejelentkezés")
        this.router.navigateByUrl("/home")
        localStorage.setItem("token",res.data)
        console.log(res)
        let token = localStorage.getItem("token")
        this.userAuthService.getUserData(token).subscribe((res)=>{
          console.log(res.data[0].felhasznalo_nev)
          localStorage.setItem("userData",res.data[0])
          localStorage.setItem("userName",res.data[0].felhasznalo_nev)
          this.appcomponent.setUserData()
        })
      }
    })
  }

}
