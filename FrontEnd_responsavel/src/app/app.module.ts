import { BrowserModule } from '@angular/platform-browser';
import { NgModule,  } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { AddColaboradorComponent } from './components/colaborador/colaborador-add/colaborador-add.component';
import { ColaboradorDetailsComponent } from './components/colaborador/colaborador-details/colaborador-details.component';
import { ColaboradorListComponent } from './components/colaborador/colaborador-list/colaborador-list.component';
import { PesquisaListComponent } from './components/pesquisa/pesquisa-list.component';


@NgModule({
  declarations: [
    AppComponent,
    AddColaboradorComponent ,
    ColaboradorDetailsComponent ,
    ColaboradorListComponent,
    PesquisaListComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }