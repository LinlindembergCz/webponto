import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PesquisaService {

  baseUrl = '';   

  constructor(private http: HttpClient ) { 
    this.baseUrl = environment.BaseApontamentoURL + 'listapontos/';

  }

 
  find(matricula : string =''): Observable<any[]> {
     
      return this.http.get<any[]>(this.baseUrl+matricula);

  }
}
