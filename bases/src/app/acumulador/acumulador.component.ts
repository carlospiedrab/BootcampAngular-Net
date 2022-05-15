import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-acumulador',
  templateUrl: './acumulador.component.html',
  styleUrls: ['./acumulador.component.css']
})
export class AcumuladorComponent implements OnInit {

  title: string = 'Angular Bases';

  numero: number = 2;

  duplicar() {
    this.numero = this.numero * 2;
  }

  triplicar() {
    this.numero = this.numero * 3;
  }

  reiniciar(){
    this.numero = 2;
  }


  constructor() { }

  ngOnInit(): void {
  }

}
