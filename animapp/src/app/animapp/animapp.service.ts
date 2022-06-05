import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Datos, IAnimApp } from './interfaces/animapp';

@Injectable({
  providedIn: 'root'
})
export class AnimappService {

  apiKey: string = "LB84Xm5XEOnTj9jjT5aGyXuC4obrnBuy";
  resultados: Datos[] = [];

  constructor(private http: HttpClient) { }


  buscarGifs(query: string){
  this.http.get<IAnimApp>(`https://api.giphy.com/v1/gifs/search?api_key=${this.apiKey}&q=${query}&limit=10`)
            .subscribe(resp => {
              this.resultados = resp.data;
            })
  }

}
