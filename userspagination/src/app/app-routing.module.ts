import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListadoUsuariosComponent } from './usuarios/listado-usuarios/listado-usuarios.component';

const routes: Routes = [
 {
  path: '', component: ListadoUsuariosComponent, pathMatch: 'full'
 },
 {
  path:'**', redirectTo:''
 }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
