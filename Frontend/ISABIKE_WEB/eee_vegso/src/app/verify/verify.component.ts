import { Component, OnInit } from '@angular/core';
import { UserAuthService } from '../user-auth.service';
import { Router } from '@angular/router';
import { VerifyPayload } from '../user';

@Component({
  selector: 'app-verify',
  templateUrl: './verify.component.html',
  styleUrls: ['./verify.component.css']
})
export class VerifyComponent implements OnInit {
  code: string = '';
  isSubmitting: boolean = false;
  validationErrors: any = [];
  verificationSuccess: boolean = false; 

  constructor(public userAuthService: UserAuthService, private router: Router) { }

  ngOnInit(): void {
    
  }

  verifyAccount() {
    this.isSubmitting = true;
    let payload: VerifyPayload= {
      code: this.code,
    };
    this.userAuthService.verifyAccount(payload)
      .then(({ data }) => {
        //localStorage.setItem('token', data.token);
        this.verificationSuccess = true;
        this.router.navigateByUrl('/home');
        return data;
      })
      .catch(error => {
        this.isSubmitting = false;
        if (error.response.data.errors !== undefined) {
          this.validationErrors = error.response.data.errors;
        }
        return error;
      });
  }
}
