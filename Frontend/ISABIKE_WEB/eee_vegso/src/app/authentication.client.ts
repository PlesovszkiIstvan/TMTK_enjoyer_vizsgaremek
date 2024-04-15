import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root',
})

export class AuthenticationClient{

    private url = "http://127.0.0.1:8000/api";
    
    constructor(private http: HttpClient){}

    public register(felhasznalo_nev:string, kereszt_nev:string, vezetek_nev:string, email:string, password:string): Observable<any>{
        return this.http.post('http://127.0.0.1:8000/api/registration', 
        {
            felhasznalo_nev:felhasznalo_nev,
            kereszt_nev:kereszt_nev,
            vezetek_nev:vezetek_nev,
            email:email,
            password:password
        }
    )
    }

}