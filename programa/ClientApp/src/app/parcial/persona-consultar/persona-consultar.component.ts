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
  }
  get(){
    this.personaService.get().subscribe(result => {
      this.personas = result;
  })}

}
