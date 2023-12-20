import { Component } from '@angular/core';

@Component({
  selector: 'app-biciklik',
  templateUrl: './biciklik.component.html',
  styleUrl: './biciklik.component.css'
})
export class BiciklikComponent {
  products = [
    { name: 'Product 1', description: 'Description 1', price: 19.99, image: 'kerekpar1.jpg' },
    { name: 'Product 2', description: 'Description 2', price: 29.99, image: 'kerekpar2.jpg' },
    { name: 'Product 3', description: 'Description 3', price: 39.99, image: 'kerekpar1.jpg' },
    { name: 'Product 4', description: 'Description 4', price: 49.99, image: 'kerekpar2.jpg' },
    { name: 'Product 5', description: 'Description 5', price: 59.99, image: 'kerekpar1.jpg' },
    { name: 'Product 6', description: 'Description 6', price: 69.99, image: 'kerekpar2.jpg' },
  ];

}
