import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { EmpleadoService } from '../empleado.service';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styleUrls: ['./listado.component.css']
})
export class ListadoComponent implements OnInit {

  displayedColumns: string[] = ['apellidos', 'nombres', 'cargo', 'compania']

  constructor(private empleadoService: EmpleadoService) { }

  ngOnInit(): void {
      this.empleadoService.listarEmpleados();
  }

  get resultados(){
    return this.empleadoService.resultados;
  }

  get totalRegistros(){
     return this.empleadoService.totalRegistros;
  }

  get registrosPorPagina(){
     return this.empleadoService.registrosPorPagina;
  }

  onPaginadoChange(event: PageEvent){
     let pagina = event.pageIndex;
     let size = event.pageSize;
     pagina++;
     this.empleadoService.listarEmpleados(pagina, size);
  }

}
