import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';
import { GetToken } from 'src/app/Apoyo/Token';

@Component({
  selector: 'alta_psicologo',
  templateUrl: './alta.psicologo.component.html',
  styleUrls: ['./alta.psicologo.component.css'],
})
export class AltaPsicologoComponent implements OnInit {
  urlBase = '';

  formatoConsultaTexto: string = 'Virtual';
  formatoConsultaNumerico: number = 0;
  dolenciasQueTrata: any[] = [];
  precioPsicologo: number = 500;
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
  }

  SetFormatoConsulta(numero: number) {
    this.formatoConsultaTexto = this.ParseFormatoConsulta(numero);
    this.formatoConsultaNumerico = numero;
  }

  ParseFormatoConsulta(numero: number): string {
    switch (numero) {
      case 0:
        return 'Virtual';
        break;
      case 1:
        return 'Presencial';
        break;
      default:
        return 'Error';
        break;
    }
  }

  Registrar() {
    console.log('Registrando Psicologo');
    const nombrePsicologo = (<HTMLSelectElement>(
      document.getElementById('nombrePsicologo')
    )).value;
    const formatoConsulta = this.formatoConsultaNumerico;
    const direccionUrbana = (<HTMLSelectElement>(
      document.getElementById('direccionUrbana')
    )).value;
    this.AgregarDolenciasQueTrataPsicologo();
    const precioHora = this.precioPsicologo;

    const objetoPsicologo = {
      ID: 0,
      Nombre: nombrePsicologo,
      FormatoConsulta: formatoConsulta,
      DireccionUrbana: direccionUrbana,
      PrecioHora: precioHora,
      DolenciasQueTrata: this.dolenciasQueTrata,
    };

    console.log(objetoPsicologo);

    this.http
      .post<any>(
        this.urlBase + '/Psicologia/RegistrarPsicologo',
        objetoPsicologo,
        this.httpOptions
      )
      .subscribe(
        (result) => {
          alert(result.mensaje);
        },
        (error) => ProcesarRespuesta(error.error)
      );
    this.dolenciasQueTrata = [];
  }

  SetVariablePrecio(precio: number) {
    this.precioPsicologo = precio;
  }

  AgregarDolenciasQueTrataPsicologo() {
    for (let i = 1; i <= 3; i++) {
      let elementoSelectDolenciaHTML = 'd' + i;
      const elementoSelectDolencia = document.getElementById(
        elementoSelectDolenciaHTML
      ) as HTMLSelectElement;
      var sel = elementoSelectDolencia.selectedIndex;
      var opt = elementoSelectDolencia.options[sel].value;
      if (opt != '-1') {
        this.AgregarDolenciasQueTrataPsicologoComoObjeto(opt);
      }
    }
  }

  AgregarDolenciasQueTrataPsicologoComoObjeto(opt: any) {
    var objeto = {
      Dolencia: +opt,
    };
    this.dolenciasQueTrata.push(objeto);
  }
}
