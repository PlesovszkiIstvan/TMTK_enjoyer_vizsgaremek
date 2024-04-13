import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CartService } from '../cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rendeles',
  templateUrl: './rendeles.component.html',
  styleUrls: ['./rendeles.component.css']
})
export class RendelesComponent {
  orderForm!: FormGroup;
  szalitoText: string = 'GLS';
  fizetesText: string = 'Utánvét';
  kedvezmenyText: string = 'Nincs';

  constructor(private formBuilder: FormBuilder, private cart: CartService, private router : Router) { }

  ngOnInit(): void {
    this.orderForm = this.formBuilder.group({
      vasarlo_telefonszama: ['', Validators.required],
      szalitasi_cime: ['', Validators.required],
      megjegyzes: [''],
      szalito_id: [1],
      fizetes_opcio_id: [1],
      kedvezmeny_id: [1],
      token:localStorage.getItem("token")
    });
  }

  onSubmit(): void {
    if (this.orderForm.valid) {
      this.cart.submitOrder(this.orderForm.value).subscribe((response:any) => {
        alert("Rendelése sikeresen rögzítve, tekintse meg emailjei közt a részleteket")
        this.router.navigateByUrl("/home")
      },( error:any)=> {
        alert(" A rendelés folyamán hiba lépett fel, kérem próbálja újra.")
        this.router.navigateByUrl("/kosar")
        console.error('Error submitting form:', error);
      });
    } else {
      this.orderForm.markAllAsTouched();
    }
  }
}

