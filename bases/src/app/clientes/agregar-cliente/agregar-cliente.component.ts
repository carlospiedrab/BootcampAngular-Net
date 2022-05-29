import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ClientesService } from '../clientes.service';
import { ICliente } from '../interfaces/cliente';

@Component({
  selector: 'app-agregar-cliente',
  templateUrl: './agregar-cliente.component.html',
  styleUrls: ['./agregar-cliente.component.css']
})
export class AgregarClienteComponent implements OnInit {

  nuevo: ICliente = {
    nombre: '',
    credito: 0
  }

  // @Output()
  // onNuevoCliente: EventEmitter<ICliente> = new EventEmitter();

  constructor(private clientesService: ClientesService) { }

  ngOnInit(): void {
  }

  agregar(){
    // console.log(this.nuevo);
    if(this.nuevo.nombre.trim().length ===0){
      return;
    }
    if(this.nuevo.credito === null){
      return;
    }

    // this.onNuevoCliente.emit(this.nuevo);
    this.clientesService.agregarCliente(this.nuevo);

    this.nuevo = {
      nombre:'',
      credito:0
    }

  }


}
