import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import {PersonaService } from './../../services/persona.service'

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consultar.component.html',
  styleUrls: ['./persona-consultar.component.css']
})
export class PersonaConsultarComponent implements OnInit {
  personas:Persona[];
  searchText:string;
  suma: string ="" ;
  
  constructor(private personaService : PersonaService) { }

  ngOnInit() {
    this.get();    
    this.SumaAyudas();
   
  }
  get(){
    this.personaService.get().subscribe(result => {
      this.personas = result;
      
  })}
   SumaAyudas(){
    this.personaService.SumasAyudas().subscribe(result => {
      this.suma = result.toString();
      console.log(this.suma);
    })}

}
