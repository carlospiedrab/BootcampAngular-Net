import { Injectable } from '@angular/core';
import { ICliente } from './interfaces/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  private _clientes: ICliente[] = []

  get clientes(): ICliente[] {
    return this._clientes
  }

  agregarCliente(cliente: ICliente){
    this._clientes.push(cliente);
    localStorage.setItem('clientes',JSON.stringify(this._clientes));
  }

  constructor() {
    console.log('Servicio Inicializado')
    this._clientes = JSON.parse(localStorage.getItem('clientes')!) || [];
   }
}
