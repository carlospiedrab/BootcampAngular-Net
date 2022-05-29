import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginaInicioComponent } from './pagina-inicio/pagina-inicio.component';
import { FormsModule } from '@angular/forms';
import { ListadoClientesComponent } from './listado-clientes/listado-clientes.component';
import { AgregarClienteComponent } from './agregar-cliente/agregar-cliente.component';
import { ClientesService } from './clientes.service';



@NgModule({
  declarations: [
    PaginaInicioComponent,
    ListadoClientesComponent,
    AgregarClienteComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    PaginaInicioComponent,
    ListadoClientesComponent
  ],
  providers: [
     ClientesService
  ]
})
export class ClientesModule { }
