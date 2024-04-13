import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BiciklikComponent } from './biciklik/biciklik.component';
import { TermekComponent } from './termek/termek.component';

import { LoginComponent } from './login/login.component';
import { RolunkComponent } from './rolunk/rolunk.component';
import { RegisterComponent } from './register/register.component';
import { VerifyComponent } from './verify/verify.component';
import { TokenInterceptor } from './token.interceptor';
import { KosarComponent } from './kosar/kosar.component';
import { RendelesComponent } from './rendeles/rendeles.component';
import { UserRendelesComponent } from './user-rendeles/user-rendeles.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BiciklikComponent,
    TermekComponent,
    RolunkComponent,
    LoginComponent,
    RegisterComponent,
    VerifyComponent,
    KosarComponent,
    RendelesComponent,
    UserRendelesComponent,

    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
