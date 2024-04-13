import { Component } from '@angular/core';
import { CartService } from '../cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-kosar',
  templateUrl: './kosar.component.html',
  styleUrls: ['./kosar.component.css']
})
export class KosarComponent {
  shoppingCartData?: any[];
  constructor(private cart: CartService, private router: Router) {

  }
  ngOnInit(): void {
    this.getItems()
  }
  getItems() {
    this.cart.getCartItems().subscribe((res) => {
      if (res.success == true) {
        console.log(res)
        this.shoppingCartData = res.data;
      }
    },(error)=>{
      console.log(error)
      alert("Üres a kosarad")
      this.router.navigateByUrl("/biciklik")
    })
  }
  deleteItem(id: any) {
    this.cart.removeCartItem(id).subscribe((res) => {
      alert("Sikeres törlés")
    })
    this.getItems()
  }
}
