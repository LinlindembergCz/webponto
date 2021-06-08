import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ColaboradorListComponent } from './components/colaborador/colaborador-list/colaborador-list.component';
import { ColaboradorDetailsComponent } from './components/colaborador/colaborador-details/colaborador-details.component';
import { AddColaboradorComponent } from './components/colaborador/colaborador-add/colaborador-add.component';
import { PesquisaListComponent } from './components/pesquisa/pesquisa-list.component';



const routes: Routes = [
  { path: '', redirectTo: 'colaborador', pathMatch: 'full' },
  { path: 'colaborador', component: ColaboradorListComponent },
  { path: 'colaborador/:id', component: ColaboradorDetailsComponent },
  { path: '', redirectTo: 'colaboradorplanets', pathMatch: 'full' },
  { path: 'colaboradorplanets', component: PesquisaListComponent },  
  { path: 'addColaborador', component: AddColaboradorComponent },];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule 
{
 

 }
