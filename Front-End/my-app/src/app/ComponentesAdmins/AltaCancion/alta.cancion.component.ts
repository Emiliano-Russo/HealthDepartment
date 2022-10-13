import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';
import { GetToken } from '../../Apoyo/Token';

@Component({
  selector: 'alta_cancion',
  templateUrl: './alta.cancion.component.html',
  styleUrls: ['alta.cancion.component.css'],
})
export class AltaCancionComponent implements OnInit {
  urlBase = '';
  listaPlayLists: any[] = [];
  listaCategorias: any[] = [];
  playListsSeleccionadas: number[] = [];
  categoriasSelccionadas: any[] = [];
  httpOptions: any;

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
    this.httpOptions = GetToken();
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

  DarAltaCancion() {
    const tituloCancion = (<HTMLSelectElement>(
      document.getElementById('tituloCancion')
    )).value;
    const descripcionCancion = (<HTMLSelectElement>(
      document.getElementById('descripcionCancion')
    )).value;
    const duracionCancion = (<HTMLSelectElement>(
      document.getElementById('duracionCancion')
    )).value;
    const autorCancion = (<HTMLSelectElement>(
      document.getElementById('autorCancion')
    )).value;
    const linkCancion = (<HTMLSelectElement>(
      document.getElementById('linkCancion')
    )).value;
    const imagenCancion = (<HTMLSelectElement>(
      document.getElementById('linkImagen')
    )).value;

    const objetoCancion = {
      ID: 0,
      Titulo: tituloCancion,
      Descripcion: descripcionCancion,
      Duracion: +duracionCancion,
      Autor: autorCancion,
      LinkAudio: linkCancion,
      LinkImagen: imagenCancion,
      CategoriaMusical: this.categoriasSelccionadas,
    };

    const objetoPost = {
      Cancion: objetoCancion,
      IdPlayLists: this.playListsSeleccionadas,
    };

    this.Registro(objetoPost);
  }

  Registro(objetoPost: any) {
    if (objetoPost.IdPlayLists.length > 0) {
      this.RegistrarCancionConPlayList(objetoPost);
    } else {
      this.RegistrarCancion(objetoPost.Cancion);
    }
  }

  RegistrarCancionConPlayList(objeto: any) {
    this.http
      .post<any>(
        this.urlBase + '/Musica/RegistrarCancionConPlayLists',
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

  RegistrarCancion(cancion: any) {
    this.http
      .post<any>(
        this.urlBase + '/Musica/RegistrarCancion',
        cancion,
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

  AgregarCancionEnPlayList(playlistId: number) {
    this.playListsSeleccionadas.push(playlistId);
  }

  AgregarCategoriaParaCancion(categoria: string): void {
    let numeroCategoria = this.ParseNombreGaleria(categoria);
    let objeto = {
      Musical: numeroCategoria,
    };
    this.categoriasSelccionadas.push(objeto);
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
    const idBotonRegistro = 'AltaCancion';
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
