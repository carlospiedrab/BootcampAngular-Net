import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-basicos',
  templateUrl: './basicos.component.html',
  styleUrls: ['./basicos.component.css']
})
export class BasicosComponent implements OnInit {

  nombre: string = "carlos";
  apellido: string = "Piedra";
  nombreCompleto: string = this.nombre+" "+this.apellido;

  fecha: Date = new Date();

  constructor() { }

  ngOnInit(): void {
  }

}
