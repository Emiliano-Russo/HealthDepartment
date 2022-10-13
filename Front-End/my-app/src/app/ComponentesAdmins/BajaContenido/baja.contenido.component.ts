import { Component, HostListener, Inject, OnInit } from '@angular/core';
import {
  HttpClient,
  JsonpClientBackend,
  HttpHeaders,
} from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';

@Component({
  selector: 'baja_contenido',
  templateUrl: './baja.contenido.component.html',
  styleUrls: ['./baja.contenido.component.css'],
})
export class BajaContenidoComponent implements OnInit {
  urlBase = '';
  listaCanciones: any[] = [];
  listaVideos: any[] = [];
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      token: sessionStorage.getItem('token') + '',
    }),
    body: {},
  };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.urlBase = this.baseUrl;
    this.GetTodasLasCanciones();
    this.GetTodosLosVideos();
  }

  GetTodasLasCanciones() {
    this.http.get<any>(this.urlBase + '/Musica/GetTodasLasCanciones').subscribe(
      (result) => {
        this.listaCanciones = result.mensaje;
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  GetTodosLosVideos() {
    this.http.get<any>(this.urlBase + '/Musica/GetTodosLosVideos').subscribe(
      (result) => {
        this.listaVideos = result.mensaje;
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  EliminarCancion(titulo: string, autor: string) {
    const objetoJson = {
      Autor: autor,
      Titulo: titulo,
    };
    this.httpOptions.body = objetoJson;
    this.http
      .delete<any>(this.urlBase + '/Musica/BorrarCancion', this.httpOptions)
      .subscribe(
        (result) => {
          ProcesarRespuesta(result);
          this.GetTodasLasCanciones();
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  EliminarVideo(idVideo: number) {
    console.log('Llega el id: ' + idVideo);
    this.httpOptions.body = idVideo;
    this.http
      .delete<any>(this.urlBase + '/Musica/BorrarVideo', this.httpOptions)
      .subscribe(
        (result) => {
          ProcesarRespuesta(result);
          this.GetTodosLosVideos();
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  @HostListener('document:click', ['$event'])
  documentClick(event: MouseEvent) {
    // your click logic
    const boton = <HTMLInputElement>event.target;
    const tagName = (<HTMLInputElement>event.target).tagName;
    if (tagName == 'BUTTON') {
      boton.style.display = 'none';
    }
  }
}
