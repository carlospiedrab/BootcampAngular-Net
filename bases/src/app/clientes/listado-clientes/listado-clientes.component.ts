import { Component, Input, OnInit } from '@angular/core';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-listado-clientes',
  templateUrl: './listado-clientes.component.html',
  styleUrls: ['./listado-clientes.component.css']
})
export class ListadoClientesComponent implements OnInit {

  @Input()
  clientes: ICliente[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
