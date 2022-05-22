import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmpleadoComponent } from './empleado/empleado.component';
import { ListadoComponent } from './listado/listado.component';



@NgModule({
  declarations: [
    EmpleadoComponent,
    ListadoComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    EmpleadoComponent,
    ListadoComponent
  ]
})
export class EmpleadosModule { }
