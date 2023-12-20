import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  brands = [
    'brand1.jpg',
    'brand2.jpg',
    'brand3.jpg',
    'brand4.jpg',
    'brand5.jpg',
  ];
  products = [
    { name: 'Product 1', description: 'Description 1 of the best bike Description 1 of the best bike ', price: 19.99, image: 'kerekpar1.jpg' },
    { name: 'Product 2', description: 'Description 2', price: 29.99, image: 'kerekpar2.jpg' },
    { name: 'Product 3', description: 'Description 3', price: 39.99, image: 'kerekpar1.jpg' },
    { name: 'Product 4', description: 'Description 4', price: 49.99, image: 'kerekpar2.jpg' },
    { name: 'Product 5', description: 'Description 5', price: 59.99, image: 'kerekpar1.jpg' },
    { name: 'Product 6', description: 'Description 6', price: 69.99, image: 'kerekpar2.jpg' },
  ];
}
