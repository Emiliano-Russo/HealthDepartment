import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Component({
  selector: 'agendar_cita',
  templateUrl: './agendar.cita.component.html',
})
export class AgendarCitaComponent implements OnInit {
  urlBase = '';
  categoriasPsicologicas: string[] = [];
  dolencia: number = 0;
  dolenciaString: string = '';
  cantHorasSeleccionadas: any = 1;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
    const navegacion = this.ruta?.getCurrentNavigation();
    if (navegacion != null) {
      this.dolencia = navegacion.extras.state?.nombreCategoria;
      this.dolenciaString = this.ConversionCategoria(this.dolencia);
      console.log('Dolenciaaa: ' + this.dolencia);
    }
  }

  ngOnInit(): void {}

  RegistrarCita() {
    const nombre = (<HTMLSelectElement>document.getElementById('Nombre')).value;
    const apellido = (<HTMLSelectElement>document.getElementById('Apellido'))
      .value;
    const fechaNacimiento = (<HTMLSelectElement>(
      document.getElementById('fechaNacimiento')
    )).value;
    const email = (<HTMLSelectElement>document.getElementById('email')).value;
    const celular = (<HTMLSelectElement>document.getElementById('celular'))
      .value;
    const cantidadHoras = this.cantHorasSeleccionadas;
    const objeto = {
      Nombre: nombre,
      Apellido: apellido,
      FechaNacimiento: fechaNacimiento,
      Email: email,
      NumeroCelular: celular,
      Dolencia: this.dolencia,
      TiempoSolicitadoHoras: cantidadHoras,
    };

    console.log('Objeto a enviar: ');
    console.log(objeto);
    this.http
      .post<any>(this.urlBase + '/Psicologia/PedirCita', objeto, httpOptions)
      .subscribe(
        (result) => {
          this.IrCitaResultado(result.mensaje);
          console.log(result.mensaje);
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  SetCantHoras(cantHoras: any) {
    this.cantHorasSeleccionadas = +cantHoras;
  }

  IrCitaResultado(cita: any) {
    this.ruta.navigateByUrl('/CitaResultado', {
      state: { resultadoCita: cita },
    });
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
}
