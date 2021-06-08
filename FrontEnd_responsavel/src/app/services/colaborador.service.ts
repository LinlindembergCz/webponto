import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Colaborador } from '../models/colaborador.models';
import {BaseURL} from '../constants';
import { CreateColaboradorResponse } from '../Viewmodels/CreateColaboradorResponse';

@Injectable({
  providedIn: 'root'
})
export class ColaboradorService {

  baseUrl = '';

  constructor(private http: HttpClient ) { 
    this.baseUrl = BaseURL+'colaborador';

  }

  getAll(): Observable<CreateColaboradorResponse[]> {
    return this.http.get<CreateColaboradorResponse[]>(this.baseUrl);
  }

  get(id: any): Observable<any> {
    return this.http.get(`${this.baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(this.baseUrl, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  deleteAll(): Observable<any> {
    return this.http.delete(this.baseUrl);
  }

}
