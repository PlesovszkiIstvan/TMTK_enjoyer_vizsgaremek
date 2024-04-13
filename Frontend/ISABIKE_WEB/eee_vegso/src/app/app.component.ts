import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationPayload } from './user';
import { UserAuthService } from './user-auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'bikeapi';

  userName:any;

  constructor(private router: Router, private auth:UserAuthService) {}

  setUserData(){
    console.log(typeof(localStorage.getItem("userName")))
    this.userName = localStorage.getItem("userName");
  }

  ngOnInit(): void {
    if (this.isLoggedIn()) {
      this.setUserData()
    }
  }

  logout() {
    let token = localStorage.getItem("token")
    this.auth.logout(token).subscribe((res)=>{
      console.log(res)
      alert("Sikeres kijelentkezés")
    })
    this.router.navigateByUrl('/home');
    localStorage.removeItem('token');
    localStorage.removeItem('userData');
    localStorage.removeItem('userName');
  }
  isLoggedIn(){
    if(localStorage.getItem("token")){
        return true
    }
    else{
        return false
    }
}
}
