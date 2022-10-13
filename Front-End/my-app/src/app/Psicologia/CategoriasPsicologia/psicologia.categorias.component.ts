import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';

@Component({
  selector: 'categorias_psicologia',
  templateUrl: './psicologia.categorias.component.html',
  styleUrls: ['psicologia.categorias.component.css'],
})
export class PsicologiaCategoriasComponent implements OnInit {
  urlBase = '';
  categoriasPsicologicas: string[] = [];
  categoriasNumericas: number[] = [];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
  }
  ngOnInit(): void {
    this.GetCategoriasPsicologia();
  }

  GetCategoriasPsicologia() {
    this.http.get<any>(this.urlBase + '/Psicologia').subscribe(
      (result) => {
        this.categoriasNumericas = result.mensaje;
        this.categoriasPsicologicas = this.ConversionCategorias(result.mensaje);
      },
      (error) => {
        ProcesarRespuesta(error.error);
      }
    );
  }

  ConversionCategorias(categorias: number[]): string[] {
    let retorno: string[] = [];
    categorias.forEach((element) => {
      retorno[element] = this.ConversionCategoria(element);
    });
    return retorno;
  }

  ConversionCategoria(categoria: number): string {
    let nombreCat = '';

    switch (categoria) {
      case 0:
        nombreCat = 'Depresión';
        break;
      case 1:
        nombreCat = 'Estrés';
        break;
      case 2:
        nombreCat = 'Ansiedad';
        break;
      case 3:
        nombreCat = 'Autoestima';
        break;
      case 4:
        nombreCat = 'Enojo';
        break;
      case 5:
        nombreCat = 'Relaciones';
        break;
      case 6:
        nombreCat = 'Duelo';
        break;
      default:
        nombreCat = 'Otros';
        break;
    }

    return nombreCat;
  }

  ConversionCategoriaANumero(categoria: string): number {
    switch (categoria) {
      case 'Depresión':
        return 0;
        break;

      case 'Estrés':
        return 1;
        break;

      case 'Ansiedad':
        return 2;
        break;

      case 'Autoestima':
        return 3;
        break;

      case 'Enojo':
        return 4;
        break;

      case 'Relaciones':
        return 5;
        break;

      case 'Duelo':
        return 6;
        break;
      default:
        return 7;
        break;
    }
  }

  IrAgendarCita(categoria: string) {
    let cat = this.ConversionCategoriaANumero(categoria);
    this.ruta.navigateByUrl('/AgendarCita', {
      state: { nombreCategoria: cat },
    });
  }
}
