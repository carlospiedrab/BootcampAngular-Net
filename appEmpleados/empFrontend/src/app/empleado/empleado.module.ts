import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListadoComponent } from './listado/listado.component';
import { AgregarComponent } from './agregar/agregar.component';
import { EditarComponent } from './editar/editar.component';
import { EliminarComponent } from './eliminar/eliminar.component';
import { HomeComponent } from './home/home.component';
import { EmpleadoRoutingModule } from './empleado-routing.module';
import { MaterialModule } from '../material/material.module';
import { EmpleadoService } from './empleado.service';



@NgModule({
  declarations: [
    ListadoComponent,
    AgregarComponent,
    EditarComponent,
    EliminarComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    EmpleadoRoutingModule,
    MaterialModule
  ],
  providers: [
    EmpleadoService
  ]
})
export class EmpleadoModule { }
