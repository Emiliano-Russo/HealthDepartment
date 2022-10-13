import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from '../../Apoyo/ManejoRespuesta'

@Component({
  selector: 'baja_psicologo',
  templateUrl: './baja.psicologo.component.html',
  styleUrls: ['baja.psicologo.component.css'],
})
export class BajaPsicologoComponent implements OnInit {
  urlBase = '';
  listaPsicologos = [];
  httpOptions = {
    headers: new HttpHeaders({
      token: sessionStorage.getItem('token') + '',
    }),
  };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
    this.GetTodosLosPsicologos();
  }

  GetTodosLosPsicologos() {
    this.http
      .get<any>(this.urlBase + '/Psicologia/GetTodosLosPsicologos', this.httpOptions)
      .subscribe((result) => {
        this.listaPsicologos = result.mensaje;
      }, error =>{
        ProcesarRespuesta(error.error);
      });
  }

  EliminarPsicologo(idPsicologo: number) {
    const objetoJson = {
      id: idPsicologo,
    };
    const httpDeleteOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        token: sessionStorage.getItem('token') + '',
      }),
      body: idPsicologo,
    };

    this.http
      .delete<any>(
        this.urlBase + '/Psicologia/EliminarPsicologo',
        httpDeleteOptions
      )
      .subscribe((result) => {
        ProcesarRespuesta(result);
      }, error =>{
        ProcesarRespuesta(error.error);
      });
  }

  @HostListener('document:click', ['$event'])
  documentClick(event: MouseEvent) {
    // your click logic
    const boton = <HTMLInputElement>event.target;
    const tagName = (<HTMLInputElement>event.target).tagName;
    if (tagName == 'BUTTON') {
      const estiloElementoPadre = boton.parentElement?.style;
      if (estiloElementoPadre != undefined) {
        estiloElementoPadre.display = 'none';
      }
    }
  }
  ngOnInit(): void {}
}
