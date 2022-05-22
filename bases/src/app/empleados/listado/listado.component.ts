import { Component, Input, OnInit } from '@angular/core';
import { IEmpleado } from '../interfaces/empleado';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styleUrls: ['./listado.component.css']
})
export class ListadoComponent implements OnInit {

  etiquetaBorrado: string = '';

  @Input()
  empleados: IEmpleado[] = [];

  @Input()
  titulo :string ='';

  borrar(){
    // console.log("El boton funciona");
    const emp = this.empleados.shift();
    if(emp !==undefined){
      this.etiquetaBorrado = emp?.nombres+ ' ' + emp?.apellidos;
    }
    else {
      this.etiquetaBorrado='';
    }

  }

  constructor() { }

  ngOnInit(): void {
  }

}
