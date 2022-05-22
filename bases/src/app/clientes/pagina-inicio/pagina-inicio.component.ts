import { Component, OnInit } from '@angular/core';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-pagina-inicio',
  templateUrl: './pagina-inicio.component.html',
  styleUrls: ['./pagina-inicio.component.css']
})
export class PaginaInicioComponent implements OnInit {

  nuevo: ICliente = {
    nombre: '',
    credito: 0
  }

  clientes: ICliente[] = [
    {
      nombre: 'Carlos',
      credito: 5000
    },
    {
      nombre: 'Carmen',
      credito: 4500
    }
  ]

  constructor() { }

  ngOnInit(): void {
  }


  agregar(){
    // console.log(this.nuevo);
    if(this.nuevo.nombre.trim().length ===0){
      return;
    }
    if(this.nuevo.credito === null){
      return;
    }

    this.clientes.push(this.nuevo);
    this.nuevo = {
      nombre:'',
      credito:0
    }

  }
}
