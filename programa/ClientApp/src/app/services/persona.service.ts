import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import {Persona} from './../Parcial/models/persona';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handdleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }


  post(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona).pipe(
      tap(_ => this.handdleErrorService.log('datos enviados')),
      catchError(this.handdleErrorService.handleError<Persona>('Registrar Persona', null))
    );
  }
  get(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.baseUrl + 'api/Persona').pipe(
      tap(_ => this.handdleErrorService.log('Datos')),
      catchError(this.handdleErrorService.handleError<Persona[]>('Consulta Persona', null))
    );
    
  }
  SumasAyudas(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'Api/PersonaAyudas').pipe(
      tap(_ => this.handdleErrorService.log('DAL')),
      catchError(this.handdleErrorService.handleError<number>('Consulta Persona', null))
    );
  }

}  

