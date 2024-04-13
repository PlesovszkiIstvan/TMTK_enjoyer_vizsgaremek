import { Component, OnInit } from '@angular/core';
import { UserAuthService } from '../user-auth.service';
import { Router } from '@angular/router';
import { RegistrationPayload } from '../user';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registerForm!: FormGroup;
  isSubmitting: boolean = false;
  validationErrors: any = [];

  constructor(public userAuthService: UserAuthService, private router: Router) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      felhasznalo_nev: new FormControl('', Validators.required),
      kereszt_nev: new FormControl('', Validators.required),
      vezetek_nev: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      }
    )
  }

  registerAction() {
    if(this.registerForm.invalid){
      return;
    }
    const {felhasznalo_nev, kereszt_nev, vezetek_nev, email, password} = this.registerForm.value;
    this.userAuthService.register(felhasznalo_nev, kereszt_nev, vezetek_nev, email, password)
    // this.isSubmitting = true;
    // let payload:RegistrationPayload = {
    //   userName: this.userName,
    //   firstName: this.firstName, 
    //   lastName: this.lastName,
    //   email: this.email,
    //   password: this.password
    // };

    // this.userAuthService.register(payload)
    //   .then(({ data }) => {
    //     localStorage.setItem('token', data.token);
    //     this.router.navigateByUrl('/verify');
    //     return data;
    //   }).catch(error => {
    //     this.isSubmitting = false;
    //     if (error.response.data.errors !== undefined) {
    //       this.validationErrors = error.response.data.errors;
    //     }
    //     return error;
    //   });
  }
}
