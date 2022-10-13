import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';
import { GetToken } from '../../Apoyo/Token';

@Component({
  selector: 'lista_psicologos_modificables',
  templateUrl: './lista.psicologos.modificables.component.html',
  styleUrls: ['./lista.psicologos.modificables.component.css'],
})
export class ListaPsicologosModificablesComponent implements OnInit {
  urlBase = '';
  psicologos: any;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
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
  ngOnInit(): void {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        token: sessionStorage.getItem('token') + '',
      }),
    };
  }

  GetTodosLosPsicologos() {
    this.http
      .get<any>(
        this.urlBase + '/Psicologia/GetTodosLosPsicologos',
        this.httpOptions
      )
      .subscribe(
        (result) => {
          this.psicologos = result.mensaje;
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  IrModificarPsicologo(objetoPsicologo: any) {
    this.ruta.navigateByUrl('/ModificarPsicologo', {
      state: { psicologo: objetoPsicologo },
    });
  }
}
