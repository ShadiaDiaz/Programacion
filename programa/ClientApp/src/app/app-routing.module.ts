import {PersonaConsultarComponent } from './parcial/persona-consultar/persona-consultar.component';
import {PersonaRegistroComponent } from './parcial/persona-registro/persona-registro.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
{
path: 'personaConsulta',
component: PersonaConsultarComponent
},
{
path: 'personaRegistro',
component: PersonaRegistroComponent
}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
