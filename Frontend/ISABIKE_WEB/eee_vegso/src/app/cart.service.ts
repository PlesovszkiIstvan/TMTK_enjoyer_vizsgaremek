import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private baseURL = 'http://127.0.0.1:8000/api';

  constructor(private http: HttpClient) { }

  addToCart(productId: any,quantity:number): Observable<any> {
    const token = localStorage.getItem("token")
    return this.http.post<any>(`${this.baseURL}/addkosar`, { token: token, termek_id: productId, darabszam: quantity });
  }

  getCartItems():Observable<any>{
    const token = localStorage.getItem("token")
    return this.http.post(`${this.baseURL}/getonekosar`,{token:token})
  }

  updateCartItem(cartItemId: number, quantity: number): Observable<any> {
    return this.http.put<any>(`${this.baseURL}/updatekosar`, { id: cartItemId, quantity: quantity });
  }

  removeCartItem(cartItemId: number): Observable<any> {
    const getToken = localStorage.getItem("token");
    const requestBody = { token: getToken };
    return this.http.delete<any>(`${this.baseURL}/deletekosar/${cartItemId}`, { body: requestBody });
  }

  submitOrder(orderData: any): Observable<any> {
    return this.http.post<any>(`${this.baseURL}/addrendeles`, orderData);
  }

  getOrder(): Observable<any> {
    const token = localStorage.getItem("token")
    return this.http.post<any>(`${this.baseURL}/getonerendeles`, {token:token});
  }

  getOrderData(id:any): Observable<any> {
    return this.http.get<any>(`${this.baseURL}/getonerendelestermekek/${id}`);
  }

}
