  import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import {MasseurService} from './masseur.service';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { GridMasseursComponent } from './grid-masseurs/grid-masseurs.component';

const appRoutes: Routes = [
  { path: '', component: GridMasseursComponent }
 
];

@NgModule({
  declarations: [
    AppComponent,
    GridMasseursComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [MasseurService],
  bootstrap: [AppComponent]
})
export class AppModule { }
