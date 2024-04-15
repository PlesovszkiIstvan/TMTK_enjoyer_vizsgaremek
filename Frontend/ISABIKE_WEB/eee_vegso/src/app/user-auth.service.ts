import { Injectable } from '@angular/core';
import axios from 'axios';
import { RegistrationPayload, VerifyPayload, LoginPayload} from './user';
import { AuthenticationClient } from './authentication.client';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserAuthService {
  private baseURL: string = 'http://127.0.0.1:8000/api';
  private tokenKey = 'token';

  constructor(private authenticationClient: AuthenticationClient, private http: HttpClient) { }

  setBaseURL(url: string) {
    this.baseURL = url;
  }

  public login(loginObj: any):Observable<any>{

    return this.http.post(`${this.baseURL}/login`,loginObj)
}

  public getUserData(token:any):Observable <any>{
    console.log(token)
    const tokenasd = {
      "token": token
    }
    return this.http.post(`${this.baseURL}/getonefelhasznalo`,tokenasd)
  }
 
  register(felhasznalo_nev:string, kereszt_nev:string, vezetek_nev:string, email:string, password:string): void {
    this.authenticationClient.register(felhasznalo_nev, kereszt_nev, vezetek_nev, email, password).subscribe({
      next:(response:any)=> {
        //localStorage.setItem(this.tokenKey, response.token);
        window.location.replace('/verify');
      },
      error: (error:any) => {
        console.error("Hiba történt a regisztráció során:", error);
        alert("Hiba történ a regisztráció során.")
      }
    })
    // let payload = {
    //   felhasznalo_nev: data.userName,
    //   kereszt_nev: data.firstName,
    //   vezetek_nev: data.lastName,
    //   email: data.email,
    //   password: data.password,
    // };
  }

  verifyAccount(data: VerifyPayload): Promise<any> {
    let payload = {
        code: data.code,
    };

    return axios.put(this.baseURL + '/verify', payload);
  }

  public isLoggedIn(){
    let token = localStorage.getItem(this.tokenKey);
    return token != null && token.length > 0;
  }

  public getToken():string | null{
    return this.isLoggedIn() ? localStorage.getItem(this.tokenKey): null;
  }
  public logout(asd:any):Observable <any>{
    const token = {
      "token": asd
    }
    return this.http.post(`${this.baseURL}/logout`,token)
}
}
