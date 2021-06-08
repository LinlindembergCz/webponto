import { Component, OnInit } from '@angular/core';
import { Colaborador } from 'src/app/models/colaborador.models';
import { ColaboradorService } from 'src/app/services/colaborador.service';
import { CreateColaboradorResponse } from 'src/app/Viewmodels/CreateColaboradorResponse';

@Component({
  selector: 'app-Colaborador-list',
  templateUrl: './colaborador-list.component.html',
  styleUrls: ['./colaborador-list.component.css']
})
export class ColaboradorListComponent implements OnInit {
  entyties?: CreateColaboradorResponse[];
  entity?: Colaborador;
  currentIndex = -1;
  nome = '';

  constructor(private _Service: ColaboradorService) { }

  ngOnInit(): void {
    this.retrieveEntities(); 
  }



  retrieveEntities(): void { 
    this._Service.getAll()
      .subscribe(
        data => {
          this.entyties = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.retrieveEntities();
    this.entity = undefined;
    this.currentIndex = -1;
  }

  setActiveEntity(_entity: CreateColaboradorResponse, index: number): void {
    this.entity = _entity;//{id:_entity.id, name:_entity.name}
    this.currentIndex = index;
  }

  removeAll(): void {
    this._Service.deleteAll()
      .subscribe(
        response => {
          console.log(response);
          this.refreshList();
        },
        error => {
          console.log(error);
        });
  }

  searchName(): void {
    /*this.entity = undefined;
    this.currentIndex = -1;

    this._Service.findByName(this.name)
      .subscribe(
        data => {
          this.entyties = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });*/
  }

}
