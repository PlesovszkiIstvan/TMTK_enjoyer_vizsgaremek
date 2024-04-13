import { UserAuthService } from "./user-auth.service";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()

export class TokenInterceptor implements HttpInterceptor{

    constructor(public auth: UserAuthService){}

    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>>{
        if(this.auth.isLoggedIn()){
            let newRequest = request.clone({
                setHeaders: {
                    Authorization: `Bearer $this.auth.getToken()}`,
                },
            });
            return next.handle(newRequest);
        }
        return next.handle(request);
    }
}