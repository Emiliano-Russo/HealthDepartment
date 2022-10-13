import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'cita_resultado',
  templateUrl: './cita.resultado.component.html',
})
export class CitaResultadoComponent implements OnInit {
  urlBase = '';
  datosCita = {
    nombrePsicologo: '',
    formatoConsulta: '',
    direccionConsulta: '',
    fechaConsulta: '',
    precioFinal: '',
    descuento: '',
    duracionSesion: '',
  };
  todoOk = true;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
    const navegacion = this.ruta?.getCurrentNavigation();
    if (navegacion != null) {
      this.AsignarObjetoDatosCita(navegacion.extras.state?.resultadoCita);
    }
    if (this.datosCita.nombrePsicologo == undefined) {
      this.todoOk = false;
    }
    console.log('Todo ok: ' + this.todoOk);
    console.log(this.datosCita.nombrePsicologo);
  }

  AsignarObjetoDatosCita(cita: any) {
    this.datosCita.nombrePsicologo = cita.nombrePsicologo;
    this.datosCita.formatoConsulta = this.TraducirFormato(cita.formatoConsulta);
    this.datosCita.direccionConsulta = cita.direccionConsulta;
    this.datosCita.fechaConsulta = cita.fechaConsulta;
    this.datosCita.precioFinal = cita.precioFinal;
    this.datosCita.descuento = cita.descuento;
    this.datosCita.duracionSesion = cita.duracionSesionHoras;
  }

  ngOnInit(): void {}

  TraducirFormato(formato: number): string {
    switch (formato) {
      case 0:
        return 'Virtual';
        break;
      case 1:
        return 'Presnecial';
        break;
      default:
        return 'Formato no reconocido';
        break;
    }
  }
}
