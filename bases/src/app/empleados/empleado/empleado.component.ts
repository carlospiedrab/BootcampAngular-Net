import { Component, OnInit } from '@angular/core';
import { IEmpleado } from '../interfaces/empleado';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit {

  tituloAntiguo: string = "Empleados Antiguos";
  tituloNuevo: string = "Empleados Nuevos";

  empleadosAntiguos: IEmpleado[] = [
    {
      nombres: 'carlos',
      apellidos: 'piedra',
      direccion: ' 8225 Los Angeles',
      sueldo: 5000
    },
    {
      nombres: 'alberto',
      apellidos: 'gonzales',
      direccion: ' 3520 San Fernando',
      sueldo: 3500
    },
    {
      nombres: 'manuel',
      apellidos: 'alvarado',
      direccion: ' 4020 Victory',
      sueldo: 3500
    }
  ]

  empleadosNuevos: IEmpleado[] = [
    {
      nombres: 'Roman',
      apellidos: 'Herrera',
      direccion: ' 8225 Los Angeles',
      sueldo: 5000
    },

  ]

  constructor() { }

  ngOnInit(): void {
  }

}
