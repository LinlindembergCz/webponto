import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
    console.log(data);
    return this.http.post(this.baseUrl+'entrada', data);
  }

  sair(data: any): Observable<any> {
    console.log(data);
    return this.http.post(this.baseUrl+'saida', data);
  }


}
