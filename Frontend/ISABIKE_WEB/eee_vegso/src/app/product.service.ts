import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) {}

  getProducts(): Observable<any[]> {
    return this.http.get<any[]>("http://127.0.0.1:8000/api/termekek/100");
  }
  

  getProduct(id: number): Observable<any> {
    return this.http.get<any>("http://127.0.0.1:8000/api/onetermekek/" + id);
  }
}
