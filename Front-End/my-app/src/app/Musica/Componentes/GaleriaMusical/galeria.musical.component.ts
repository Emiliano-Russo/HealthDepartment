import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { JsonCategoriasMusicales } from '../../InterfacesMusica/InterfacesCategoriasMusicales';
import { ActivatedRoute, Router } from '@angular/router';
import {
  JsonGaleriaMusical,
  GaleriaMusical,
} from '../../InterfacesMusica/InterfacesGaleriasMusicales';
import { Cancion } from '../../InterfacesMusica/InterfacesCanciones';
import { PlayList } from '../../InterfacesMusica/InterfacesPlayList';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';
import { FormateadorMinutosEnHoras } from '../../../Apoyo/Transformacion';

@Component({
  selector: 'GaleriaMusical',
  templateUrl: './galeria.musical.component.html',
  styleUrls: ['./galeria.musical.component.css'],
})
export class GaleriaMusicalComponent implements OnInit {
  urlBase = '';
  categoriasMusicales: string[] = [];
  domSanitizer: DomSanitizer;
  nombreGaleria: string = '';
  galeriaMusical!: any;
  canciones!: any;
  videos!: any;
  playlists!: any;
  linkYoutube = 'https://www.youtube.com/embed/hj83cwfOF3Y';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private sanitizer: DomSanitizer
  ) {
    this.domSanitizer = sanitizer;
    this.urlBase = baseUrl;
    const navegacion = this.ruta?.getCurrentNavigation();
    if (navegacion != null) {
      const nombre = navegacion.extras.state?.nombreGaleria;
      this.nombreGaleria = nombre;
      console.log('Nombre Galeria:' + nombre);
    } else {
      console.log('No existen parametros de navegacion');
    }
    this.galeriaMusical = {
      categoriaMusical: '',
    };
  }

  Formatear(numero: number): string {
    return FormateadorMinutosEnHoras(numero);
  }

  ngOnInit(): void {
    const numeroGaleria = this.ParseNombreGaleria(this.nombreGaleria);
    this.GetGaleriaMusical(numeroGaleria);
  }

  LimpiarURL(oldURL: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(oldURL);
  }

  GetGaleriaMusical(galeria: number) {
    this.http
      .get<any>(this.urlBase + '/Musica/GetGaleriaMusical?categoria=' + galeria)
      .subscribe(
        (result) => {
          this.galeriaMusical = result.mensaje;
          this.DistribuirGaleriaMusical();
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  DistribuirGaleriaMusical() {
    this.canciones = this.galeriaMusical.canciones;
    this.videos = this.galeriaMusical.videos;
    this.playlists = this.galeriaMusical.playLists;
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

  IrAPlaylist(id: number) {
    this.ruta.navigateByUrl('/Playlist', {
      state: { idPlaylist: id },
    });
  }

  test() {
    console.log('test');
  }
}
