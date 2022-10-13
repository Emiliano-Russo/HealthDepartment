import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';

@Component({
  selector: 'descuento_emails',
  templateUrl: './descuento.emails.component.html',
  styleUrls: ['./descuento.emails.component.css'],
})
export class DescuentoEmailsComponent implements OnInit {
  urlBase = '';
  emailSeleccionado: string = 'Ninguno';
  emails: any = [];
  descuento: number = 15;
  httpOptions = {
    headers: new HttpHeaders({
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
    this.GetTodosLosCorreosElectronicos();
  }

  SetVariablePorcentaje(numeroPorcentaje: any) {
    this.descuento = numeroPorcentaje;
  }

  GetTodosLosCorreosElectronicos() {
    this.http
      .get<any>(this.urlBase + '/Psicologia/TraerMailsAptosParaDescuentos')
      .subscribe(
        (result) => {
          this.emails = result.mensaje;
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  SeleccionarMail(email: any) {
    this.emailSeleccionado = email;
  }

  AplicarDescuento() {
    const objeto = {
      ID: 0,
      Porcentaje: this.descuento,
      Email: this.emailSeleccionado,
    };

    this.http
      .post<any>(
        this.urlBase + '/Psicologia/AplicarDescuento',
        objeto,
        this.httpOptions
      )
      .subscribe(
        (result) => {
          ProcesarRespuesta(result);
          this.variableEmailBoton.style.display = 'none';
          this.emailSeleccionado = 'Ninguno';
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  variableEmailBoton!: HTMLInputElement;
  @HostListener('document:click', ['$event'])
  documentClick(event: MouseEvent) {
    // your click logic
    const boton = <HTMLInputElement>event.target;
    const tagName = (<HTMLInputElement>event.target).tagName;
    if (tagName == 'BUTTON') {
      if (boton.id == 'email') {
        this.variableEmailBoton = boton;
      }
    }
  }
}
