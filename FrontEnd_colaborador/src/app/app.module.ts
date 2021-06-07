import { BrowserModule } from '@angular/platform-browser';
import { NgModule,  } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PontoEletronicoComponent } from './components/person/person-add/pontoEletronico.component';

@NgModule({
  declarations: [
    AppComponent,
    PontoEletronicoComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }