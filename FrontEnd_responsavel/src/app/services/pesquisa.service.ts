import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PesquisaService {

  baseUrl = '';   

  constructor(private http: HttpClient ) { 
    this.baseUrl = 'http://localhost:5001/listapontos/';

  }

 
  find(matricula : string =''): Observable<any[]> {
     
      return this.http.get<any[]>(this.baseUrl+matricula);

  }
}
