import { Component, OnInit } from '@angular/core';
import { ColaboradorService } from 'src/app/services/colaborador.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Colaborador } from 'src/app/models/colaborador.models';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-colaborador-details',
  templateUrl: './colaborador-details.component.html',
  styleUrls: ['./colaborador-details.component.css']
})
export class ColaboradorDetailsComponent implements OnInit {
  entity: Colaborador = {
    id: Guid.createEmpty(),
    nome :'',
    matricula:'',
    ativo: true
};
    
  message = '';

  constructor(
    private _Service: ColaboradorService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.get(this.route.snapshot.params.id);
  }

  get(id: string): void {
    this._Service.get(id)
      .subscribe(
        data => {
          this.entity = data;
          console.log(this.entity.id);
        },
        error => {
          console.log(error);
        });
  }

  update(): void {
    this.message = '';

    this._Service.update(this.entity.id, this.entity)
      .subscribe(
        response => {
          console.log(response);
          this.message = response.message ? response.message : 'alterado com sucesso!';
        },
        error => {
          console.log(error);
        });
  }

  delete(): void {
    this._Service.delete(this.entity.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/colaborador']);
        },
        error => {
          console.log(error);
        });
  }
}
