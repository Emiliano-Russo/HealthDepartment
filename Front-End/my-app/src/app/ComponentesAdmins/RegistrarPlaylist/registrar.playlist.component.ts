import { Component, HostListener, Inject, OnInit } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  JsonpClientBackend,
} from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';
import { Observable } from 'rxjs';
import { GetToken } from 'src/app/Apoyo/Token';

@Component({
  selector: 'registrar-playlist',
  templateUrl: './registrar.playlist.component.html',
  styleUrls: ['./registrar.playlist.component.css'],
})
export class RegistrarPlaylistComponent implements OnInit {
  urlBase = '';
  canciones = [];
  videos = [];
  listaCategorias = [];

  cancionesSeleccionadas: any[] = [];
  videosSeleccionados: any[] = [];
  categoriasSeleccionadas: any[] = [];
  httpOptions: { headers: HttpHeaders };

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
    this.GetCategoriasMusicales();
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        token: sessionStorage.getItem('token') + '',
      }),
    };
  }

  AgregarCancion(cancion: any) {
    this.cancionesSeleccionadas.push(cancion);
  }

  AgregarVideo(video: any) {
    this.videosSeleccionados.push(video);
  }

  GetTodasLasCanciones() {
    this.http.get<any>(this.urlBase + '/Musica/GetTodasLasCanciones').subscribe(
      (result) => {
        this.canciones = result.mensaje;
        console.log('Canciones: ');
        console.log(result.mensaje);
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  GetTodosLosVideos() {
    this.http.get<any>(this.urlBase + '/Musica/GetTodosLosVideos').subscribe(
      (result) => {
        this.videos = result.mensaje;
        console.log('Videos: ');
        console.log(result.mensaje);
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  GetCategoriasMusicales() {
    this.http.get<any>(this.urlBase + '/Musica').subscribe(
      (result) => {
        this.listaCategorias = result.mensaje;
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  AgregarCategoriaParaPlaylist(categoria: any) {
    const categ = this.Transformar(categoria);
    this.categoriasSeleccionadas.push(categ);
  }

  Transformar(categoria: any): any {
    let TipoCategoria = {
      Musical: 0,
    };
    switch (categoria) {
      case 'Dormir':
        TipoCategoria.Musical = 0;
        return TipoCategoria;
        break;

      case 'Meditar':
        TipoCategoria.Musical = 1;
        return TipoCategoria;
        break;

      case 'Musica':
        TipoCategoria.Musical = 2;
        return TipoCategoria;
        break;

      case 'Cuerpo':
        TipoCategoria.Musical = 3;
        return TipoCategoria;
        break;
      default:
        TipoCategoria.Musical = 0;
        return TipoCategoria;
        break;
    }
  }

  @HostListener('document:click', ['$event'])
  documentClick(event: MouseEvent) {
    const idBotonRegistro = 'registrar';
    const boton = <HTMLInputElement>event.target;
    if (boton.tagName == 'BUTTON' && boton.id != idBotonRegistro) {
      boton.style.display = 'none';
    }
  }

  async RegistrarPlaylist() {
    const nombre = (<HTMLSelectElement>document.getElementById('nombre')).value;
    const descripcion = (<HTMLSelectElement>(
      document.getElementById('descripcion')
    )).value;
    const link = (<HTMLSelectElement>document.getElementById('link')).value;
    const playlist = {
      ID: 0,
      Nombre: nombre,
      Descripcion: descripcion,
      LinkImagen: link,
      Categorias: this.categoriasSeleccionadas,
    };
    const canciones = this.cancionesSeleccionadas; // ya existen en el sistema
    const videos = this.videosSeleccionados; // ya existen en el sistema

    await this.SaveCanciones(canciones);
    await this.SaveVideos(videos);
    await this.AltaPlaylist(playlist);
  }

  async SaveVideos(videos: any[]): Promise<any> {
    const objeto = {
      Videos: videos,
    };
    return this.http
      .post<any>(this.urlBase + '/Musica/RegistrarPlayListVideo', objeto)
      .toPromise();
  }
  async SaveCanciones(canciones: any[]): Promise<any> {
    const objeto = {
      Canciones: canciones,
    };
    return this.http
      .post<any>(this.urlBase + '/Musica/RegistrarPlayListCancion', objeto)
      .toPromise();
  }

  async AltaPlaylist(playlist: any) {
    console.log('Se registrará la siguente playlist');
    console.log(playlist);
    this.http
      .post<any>(
        this.urlBase + '/Musica/RegistrarPlayList',
        playlist,
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

  ngOnInit(): void {
    this.GetTodasLasCanciones();
    this.GetTodosLosVideos();
  }
}
