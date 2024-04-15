import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; // Import Router
import { ProductService } from '../product.service';
import { CartService } from '../cart.service';

@Component({
  selector: 'app-termek',
  templateUrl: './termek.component.html',
  styleUrls: ['./termek.component.css']
})
export class TermekComponent implements OnInit {
  termek: any = [];
  constructor(private route: ActivatedRoute,
    private productService: ProductService,
    private router: Router,
    private cart: CartService) { } // Inject Router service

  ngOnInit(): void {
    this.getProductDetails();
  }

  getProductDetails(): void {
    const idString = this.route.snapshot.paramMap.get('id');
    const id = idString !== null ? +idString : null;

    if (id !== null) {
      this.productService.getProduct(id)
        .subscribe(termek => {
          console.log('Termék részletek:', termek);
          this.termek = termek;
        });
    } else {
      console.error('Az id érvénytelen vagy hiányzik.');
    }
  }
  goBack() {
    this.router.navigate(['/biciklik']);
    localStorage.removeItem("prod_id")
  }
  addCart() {
    let id = localStorage.getItem("prod_id")
    this.cart.addToCart(id,1).subscribe((res)=>{
      if(res.success == true){
        alert("Sikeresen kosárhoz adva")
        this.router.navigateByUrl("/kosar")
        localStorage.removeItem("prod_id")
      }
    })
  }
}
