import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Colaborador } from 'src/app/models/colaborador.models';
import { ColaboradorService } from 'src/app/services/colaborador.service';

@Component({
  selector: 'app-add-film',
  templateUrl: './colaborador-add.component.html',
  styleUrls: ['./colaborador-add.component.css']
})
export class AddColaboradorComponent implements OnInit {
  entity: Colaborador = {
    //id: Guid.createEmpty(),
    nome :'',
    matricula:'',
    ativo: true       
    };


  submitted = false;

  constructor(private _Service: ColaboradorService) { }

  ngOnInit(): void {
  }

  save(): void {
    this._Service.create(this.entity)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  new(): void {
    this.submitted = false;
    this.entity = {
      nome :'',
      matricula :'', 
      ativo: true
    
    };
  }

}
