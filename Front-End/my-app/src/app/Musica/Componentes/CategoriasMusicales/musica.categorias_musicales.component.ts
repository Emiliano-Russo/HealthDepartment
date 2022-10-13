import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { JsonCategoriasMusicales } from '../../InterfacesMusica/InterfacesCategoriasMusicales';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';

@Component({
  selector: 'CateogriasMusicales',
  templateUrl: './musica.categorias_musicales.component.html',
  styleUrls: ['./musica.categorias_musicales.component.css'],
})
export class CategoriasMusicalesComponent implements OnInit {
  urlBase = '';
  categoriasMusicales: string[] = [];
  nombreGaleriaMusical: any;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
  }

  ngOnInit(): void {
    this.GetCategoriasMusicales();
  }

  GetCategoriasMusicales() {
    this.http
      .get<JsonCategoriasMusicales>(this.urlBase + '/Musica')
      .subscribe((result) => {
        this.categoriasMusicales = result.mensaje;
      }, error => {
        ProcesarRespuesta(error.error);
      });
  }

  IrAGaleriaMusical(galeriaMusical: string) {
    console.log('yendo a galeria musical...' + galeriaMusical);
    this.ruta.navigateByUrl('/GaleriaMusical', {
      state: { nombreGaleria: galeriaMusical },
    });
  }
}
