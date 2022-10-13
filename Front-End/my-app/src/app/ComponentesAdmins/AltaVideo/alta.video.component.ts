import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from '../../Apoyo/ManejoRespuesta';

@Component({
  selector: 'alta_video',
  templateUrl: './alta.video.component.html',
  styleUrls: ['../AltaCancion/alta.cancion.component.css'],
})
export class AltaVideoComponent implements OnInit {
  urlBase = '';
  listaPlayLists: any[] = [];
  listaCategorias: any[] = [];
  playListsSeleccionadas: number[] = [];
  categoriasSeleccionadas: any[] = [];

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      token: sessionStorage.getItem('token') + '',
    }),
  };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.urlBase = this.baseUrl;
    this.GetTodasLasPlayList();
    this.GetTodasLasCategorias();
  }

  GetTodasLasCategorias() {
    this.http.get<any>(this.urlBase + '/Musica').subscribe(
      (result) => {
        this.listaCategorias = result.mensaje;
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  GetTodasLasPlayList() {
    this.http.get<any>(this.urlBase + '/Musica/GetTodasLasPlayList').subscribe(
      (result) => {
        this.listaPlayLists = result.mensaje;
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  DarAltaVideo() {
    const nombreVideo = (<HTMLSelectElement>(
      document.getElementById('nombreVideo')
    )).value;
    const duracionVideo = (<HTMLSelectElement>(
      document.getElementById('duracionVideo')
    )).value;
    const linkVideo = (<HTMLSelectElement>document.getElementById('linkVideo'))
      .value;
    const autorVideo = (<HTMLSelectElement>(
      document.getElementById('autorVideo')
    )).value;

    const objetoVideo = {
      Nombre: nombreVideo,
      DuracionMins: +duracionVideo,
      LinkVideo: linkVideo,
      Autor: autorVideo,
      Categorias: this.categoriasSeleccionadas,
    };

    const objetoPost = {
      Video: objetoVideo,
      IdPlayLists: this.playListsSeleccionadas,
    };

    this.Registro(objetoPost);
  }

  Registro(objetoPost: any) {
    if (objetoPost.IdPlayLists.length > 0) {
      this.RegistrarVideoConPlayList(objetoPost);
    } else {
      this.RegistrarVideo(objetoPost.Video);
    }
  }

  RegistrarVideoConPlayList(objeto: any) {
    this.http
      .post<any>(
        this.urlBase + '/Musica/RegistrarVideoConPlayLists',
        objeto,
        this.httpOptions
      )
      .subscribe(
        (result) => {
          ProcesarRespuesta(result);
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  RegistrarVideo(objeto: any) {
    this.http
      .post<any>(
        this.urlBase + '/Musica/RegistrarVideo',
        objeto,
        this.httpOptions
      )
      .subscribe(
        (result) => {
          ProcesarRespuesta(result);
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  AgregarVideoEnPlayList(idVideo: number) {
    this.playListsSeleccionadas.push(idVideo);
  }

  AgregarCategoriaParaVideo(categoria: any) {
    let numeroCategoria = this.ParseNombreGaleria(categoria);
    let objeto = {
      Musical: numeroCategoria,
    };
    this.categoriasSeleccionadas.push(objeto);
  }

  ParseNombreGaleria(nombre: string): number {
    switch (nombre) {
      case 'Dormir':
        return 0;
        break;
      case 'Meditar':
        return 1;
        break;
      case 'Musica':
        return 2;
        break;
      case 'Cuerpo':
        return 3;
        break;
      default:
        return 0;
        break;
    }
  }

  @HostListener('document:click', ['$event'])
  documentClick(event: MouseEvent) {
    const idBotonRegistro = 'AltaVideo';
    const boton = <HTMLInputElement>event.target;
    if (boton.tagName == 'BUTTON' && boton.id != idBotonRegistro) {
      boton.style.display = 'none';
      const padre = boton.parentElement;
      if (padre != null) {
        padre.style.backgroundColor = 'Chartreuse';
      }
    }
  }
}
