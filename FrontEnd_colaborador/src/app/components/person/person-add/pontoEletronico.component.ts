import { Component, OnInit } from '@angular/core';
import { PontoEletronicoService } from 'src/app/services/pontoEletronico.service';

@Component({
  selector: 'app-pontoeletronico',
  templateUrl: './pontoEletronico.component.html',
  styleUrls: ['./pontoEletronico.component.css']
})
export class PontoEletronicoComponent implements OnInit {
  
  
  matricula= "";


  submitted = false;

  constructor(private _Service: PontoEletronicoService) { }

  ngOnInit(): void {
  }

  entrar(): void {
    this._Service.entrar({matricula:this.matricula})
      .subscribe(
        response => {       
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  sair(): void {
    this._Service.sair({matricula:this.matricula})
      .subscribe(
        response => {       
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

}
