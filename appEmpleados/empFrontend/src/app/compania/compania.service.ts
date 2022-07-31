import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Compania, IDataCompania } from './interfaces/IDataCompania';

@Injectable({
  providedIn: 'root'
})
export class CompaniaService {

  apiUrl: string = environment.apiUrl;
  companiaUrl: string = `${this.apiUrl}/compania`;
  resultados: Compania[] = [];

  constructor(private http: HttpClient) { }

  listarCompanias(){
     this.http.get<IDataCompania>(this.companiaUrl)
              .subscribe(resp => {
                this.resultados = resp.resultado;
              })
  }

}
