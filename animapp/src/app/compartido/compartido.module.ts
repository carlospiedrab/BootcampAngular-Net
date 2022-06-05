import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CabeceraComponent } from './cabecera/cabecera.component';



@NgModule({
  declarations: [
    CabeceraComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CabeceraComponent
  ]
})
export class CompartidoModule { }
