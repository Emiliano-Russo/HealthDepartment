import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';
import { GetToken } from '../../Apoyo/Token';

@Component({
  selector: 'agregar_admin',
  templateUrl: './agregar.admin.component.html',
  styleUrls: ['agregar.admin.component.css'],
})
export class AgregarAdminComponent implements OnInit {
  urlBase = '';
  httpOptions: any;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.urlBase = this.baseUrl;
    this.httpOptions = GetToken();
  }

  RegistrarAdmin() {
    const email = (document.getElementById('email') as HTMLSelectElement).value;
    const constrasenia = (
      document.getElementById('contrasenia') as HTMLSelectElement
    ).value;
    const objetoJson = {
      Email: email,
      Contrasenia: constrasenia,
    };

    this.http
      .post<any>(
        this.urlBase + '/Admin/AgregarAdmin',
        objetoJson,
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
}
