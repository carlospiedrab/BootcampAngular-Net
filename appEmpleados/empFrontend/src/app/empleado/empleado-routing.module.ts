import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListadoComponent } from './listado/listado.component';
import { AgregarComponent } from './agregar/agregar.component';
import { EditarComponent } from './editar/editar.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    children: [
      {path: 'listado', component: ListadoComponent},
      {path: 'agregar', component: AgregarComponent},
      {path: 'editar/:id', component: EditarComponent},
      {path: '**', redirectTo: 'listado'}
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class EmpleadoRoutingModule { }
