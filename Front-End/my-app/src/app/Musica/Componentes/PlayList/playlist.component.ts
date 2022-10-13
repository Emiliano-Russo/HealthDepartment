import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { JsonCategoriasMusicales } from '../../InterfacesMusica/InterfacesCategoriasMusicales';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';
import { FormateadorMinutosEnHoras } from '../../../Apoyo/Transformacion';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'Playlist',
  templateUrl: './playlist.component.html',
  styleUrls: [
    './playlist.component.css',
    '../GaleriaMusical/galeria.musical.component.css',
  ],
})
export class PlayListComponent implements OnInit {
  urlBase = '';
  categoriasMusicales: any[] = [];
  idPlaylist: number = 1;
  playList: any;
  canciones: any;
  videos: any;
  private domSanitizer: DomSanitizer;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private sanitizer: DomSanitizer
  ) {
    this.urlBase = baseUrl;
    this.domSanitizer = sanitizer;
    console.log('Constructor .. idPlayList: ' + this.idPlaylist);
    const navegacion = this.ruta?.getCurrentNavigation();
    if (navegacion != null) {
      const id = navegacion.extras.state?.idPlaylist;
      this.idPlaylist = id;
      this.GetPlaylist();
    } else {
      console.log('No existe ruta de navegacion');
    }
  }

  Formatear(cantMinutos: number): string {
    return FormateadorMinutosEnHoras(cantMinutos);
  }

  LimpiarURL(oldURL: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(oldURL);
  }

  ngOnInit(): void {
    console.log('OnInit .. idPlayList: ' + this.idPlaylist);
    //this.GetPlaylist();
  }

  GetPlaylist() {
    console.log('llamada a playlist: ' + this.idPlaylist);
    this.http
      .get<any>(this.urlBase + '/Musica/GetPlayList?id=' + this.idPlaylist)
      .subscribe(
        (result) => {
          this.playList = result.mensaje;
          this.categoriasMusicales = result.mensaje.listaCategorias;
          this.canciones = result.mensaje.canciones;
          this.videos = result.mensaje.videos;
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }
}
