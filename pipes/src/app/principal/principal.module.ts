import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasicosComponent } from './basicos/basicos.component';
import { NumerosComponent } from './numeros/numeros.component';
import { OtrosComponent } from './otros/otros.component';
import { MaterialModule } from '../material/material.module';



@NgModule({
  declarations: [
    BasicosComponent,
    NumerosComponent,
    OtrosComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    BasicosComponent,
    NumerosComponent,
    OtrosComponent
  ]
})
export class PrincipalModule { }
