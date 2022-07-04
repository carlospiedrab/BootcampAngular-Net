import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-numeros',
  templateUrl: './numeros.component.html',
  styleUrls: ['./numeros.component.css']
})
export class NumerosComponent implements OnInit {

  totalVentas: number = 2555555555.2555555;
  porcentajeVentas: number = 0.56;

  constructor() { }

  ngOnInit(): void {
  }

}
