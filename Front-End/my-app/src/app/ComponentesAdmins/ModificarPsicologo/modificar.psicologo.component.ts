import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from '../../Apoyo/ManejoRespuesta';
import { GetToken } from 'src/app/Apoyo/Token';

@Component({
  selector: 'modificar_psicologo',
  templateUrl: './modificar.psicologo.component.html',
  styleUrls: ['./modificar.psicologo.component.css'],
})
export class ModificarPsicologoComponent implements OnInit {
  urlBase = '';
  dolenciasQueTrata: any = [];

  psicologo = {
    ID: 0,
    Nombre: 'Ejemplo Nombre',
    FormatoConsulta: 0,
    DireccionUrbana: 'Jackson 1234',
    PrecioHora: 0,
    DolenciasQueTrata: [],
  };

  SetFormato(n: number) {
    this.psicologo.FormatoConsulta = n;
  }

  httpOptions: any;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = this.baseUrl;
    const navegacion = this.ruta?.getCurrentNavigation();
    if (navegacion != null) {
      this.AsignarObjetoDatosPsicologo(navegacion.extras.state?.psicologo);
    }
  }

  AsignarObjetoDatosPsicologo(objetoPsicologo: any) {
    this.psicologo.ID = objetoPsicologo.id;
    this.psicologo.Nombre = objetoPsicologo.nombre;
    this.psicologo.FormatoConsulta = objetoPsicologo.formatoConsulta;
    this.psicologo.DireccionUrbana = objetoPsicologo.direccionUrbana;
    this.psicologo.PrecioHora = +objetoPsicologo.precioHora;
    this.psicologo.DolenciasQueTrata = objetoPsicologo.dolenciasQueTrata;
  }

  Registrar() {
    this.psicologo.Nombre = (
      document.getElementById('nombre') as HTMLSelectElement
    ).value;
    this.psicologo.DireccionUrbana = (
      document.getElementById('direccion') as HTMLSelectElement
    ).value;
    this.AgregarDolenciasQueTrataPsicologo();
    this.psicologo.DolenciasQueTrata = this.dolenciasQueTrata;
    console.log('----Psicologo a enviar----');
    console.log(this.psicologo);

    this.http
      .patch<any>(
        this.urlBase + '/Psicologia/ModificarPsicologo',
        this.psicologo,
        this.httpOptions
      )
      .subscribe(
        (result) => {
          this.dolenciasQueTrata = [];
          ProcesarRespuesta(result);
        },
        (error) => {
          this.dolenciasQueTrata = [];
          ProcesarRespuesta(error.error);
        }
      );
  }

  SetVariablePrecio(precio: number) {
    this.psicologo.PrecioHora = precio;
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

  ngOnInit(): void {
    this.httpOptions = GetToken();
  }
}
