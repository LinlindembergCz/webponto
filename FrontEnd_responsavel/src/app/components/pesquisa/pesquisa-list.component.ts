import { Component, OnInit } from '@angular/core';
import { PesquisaService } from 'src/app/services/pesquisa.service';
import { PontosColaboradorResponse } from 'src/app/Viewmodels/PontosColaboradorResponse';

@Component({
  selector: 'app-Pesquisa-list',
  templateUrl: './pesquisa-list.component.html',
  styleUrls: ['./pesquisa-list.component.css']
})
export class PesquisaListComponent implements OnInit {
  entyties?: PontosColaboradorResponse[];
  entity?: PontosColaboradorResponse;
  currentIndex = -1;
 
  matricula = '';
  mes = '';

  nome = '';
  dia = null;
  horas= 0;

  constructor(private _Service: PesquisaService) { }

  ngOnInit(): void {
    this.retrieveEntities();
  }

  retrieveEntities(): void {
  }

  refreshList(): void {
    this.retrieveEntities();
    this.entity = undefined;
    this.currentIndex = -1;
  }

  search(): void {
    this.entity = undefined;
    this.currentIndex = -1;

    console.log(this.matricula);
    
    this._Service.find(this.matricula)
      .subscribe(
        data => {
          this.entyties = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

}
