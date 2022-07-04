import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-otros',
  templateUrl: './otros.component.html',
  styleUrls: ['./otros.component.css']
})
export class OtrosComponent implements OnInit {

  nombre: string ="Carmen";
  genero: string = "femenino";

  usuarios: string[] = ['Carlos', 'Roberto', 'Marcela'];

  bienvenidoMapa = {
    'masculino': 'Bienvenido',
    'femenino': 'Bienvenida'
  }

  usuariosMapa = {
    '=0' : 'No hay Usuarios en Linea',
    '=1': 'Tenemos un Usuario en Linea',
    '=2': 'Tenemos 2 Usuarios en Linea',
    'other': 'Tenemos # Usuarios en Linea'
  }

  constructor() { }

  ngOnInit(): void {
  }

}
