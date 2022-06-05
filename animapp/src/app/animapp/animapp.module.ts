import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginaInicioComponent } from './pagina-inicio/pagina-inicio.component';
import { BusquedaComponent } from './busqueda/busqueda.component';
import { ResultadosComponent } from './resultados/resultados.component';
import { FormsModule } from '@angular/forms';
import { AnimappService } from './animapp.service';



@NgModule({
  declarations: [
    PaginaInicioComponent,
    BusquedaComponent,
    ResultadosComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    PaginaInicioComponent
  ],
  providers: [
    AnimappService
  ]
})
export class AnimappModule { }
