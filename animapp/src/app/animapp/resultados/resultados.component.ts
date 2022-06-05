import { Component, OnInit } from '@angular/core';
import { AnimappService } from '../animapp.service';

@Component({
  selector: 'app-resultados',
  templateUrl: './resultados.component.html',
  styleUrls: ['./resultados.component.css']
})
export class ResultadosComponent implements OnInit {

  constructor(private animaappService: AnimappService) { }

  ngOnInit(): void {
  }

  get resultados(){
    return this.animaappService.resultados;
  }

}
