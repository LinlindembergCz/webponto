import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PontoEletronicoService {

  baseUrl = '';

  constructor(private http: HttpClient ) { 
    this.baseUrl = environment.BaseURL;
  }

  entrar(data: any): Observable<any> {
    return this.http.post(this.baseUrl+'apontador/entrada', data);
  }

  sair(data: any): Observable<any> {
    return this.http.post(this.baseUrl+'apontador/saida', data);
  }


}
