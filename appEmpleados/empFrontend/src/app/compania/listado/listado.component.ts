import { Component, OnInit } from '@angular/core';
import { CompaniaService } from '../compania.service';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styleUrls: ['./listado.component.css']
})
export class ListadoComponent implements OnInit {

  displayedColumns: string[] = ['id','nombreCompania', 'direccion', 'telefono', 'telefono2'];

  constructor(private companiaService: CompaniaService) { }

  ngOnInit(): void {
    this.companiaService.listarCompanias();
  }

  get resultados(){
    return this.companiaService.resultados;
  }

}
