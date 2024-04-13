import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Router } from '@angular/router'; // Importáljuk a Router-t

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  markak = [
    'assets/markak/brand1.png',
    'assets/markak/brand2.png',
    'assets/markak/brand3.png',
    'assets/markak/brand4.png',
    'assets/markak/brand5.png',
    'assets/markak/brand6.png',
  ];

  products: any[] = [];

  constructor(private productService: ProductService, private router: Router) { } // Adjuk hozzá a Router-t a konstruktor paramétereként

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts(): void {
    this.productService.getProducts()
      .subscribe(products => {
        console.log('Products retrieved:', products);
        this.products = products;
      });
  }

  showProductDetails(productId: number): void {
    localStorage.setItem("prod_id",productId.toString())
    this.router.navigate(['/termek', productId]);
  }
}
