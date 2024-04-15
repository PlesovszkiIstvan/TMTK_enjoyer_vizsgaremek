import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from '../cart.service';

@Component({
  selector: 'app-user-rendeles',
  templateUrl: './user-rendeles.component.html',
  styleUrls: ['./user-rendeles.component.css']
})
export class UserRendelesComponent implements OnInit {
  rendelesData: any[] = [];
  rendelesTermekek: any[] = [];

  constructor(private cart: CartService, private router: Router) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems() {
    this.cart.getOrder().subscribe(
      (res) => {
        if (res.success === true) {
          this.rendelesData = res.data;
          //console.log(this.rendelesData);
        }
      },
      (error) => {
        console.log(error);
        alert('Még nincs rendelésed');
        this.router.navigateByUrl('/biciklik');
      }
    );
  }


  getRendelesTermekek(id: any) {
    this.cart.getOrderData(id).subscribe(
      (res) => {
          res.data.forEach((termek: any) => {
            alert("Termek neve: "+termek.termek_nev + "\nDarabszám: "+termek.darabszam + "\nEgység ár: " +termek.egyseg_ar + "\nÁlapot: "+ this.kezbesitve(termek.kezbesitve))
            //console.log(res.data[0])
          }
        )
      }
    )
  }

  kezbesitve(num:any){
    if (num==1) {
      return "Kézbesitve"
    } else {
      return "Kézbesités alatt"
    }
  }

  getSzalito(num:any){
    if (num==1) {
      return "GLS"
    } else if(num==2){
      return "FOXPOST"
    } else if (num==3){
      return "Magyar Posta"
    }else{
      return "DPD"
    }
    
  }

  getFizOp(num:any){
    if (num==1) {
      return "Kártyás Online"
    } else if(num==2){
      return "Utánvétel kezpenzel"
    } else{
      return "Utánvetel Kártyával"
    }
    
  }

}
