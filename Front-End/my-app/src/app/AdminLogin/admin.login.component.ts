import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from '../Apoyo/ManejoRespuesta';
import { NavMenuComponent } from '../Nav-menu/nav-menu.component';

const httpOptions = {
  headers: new HttpHeaders({
    'Conten-Type': 'application/json',
  }),
};

@Component({
  selector: 'admin_login',
  templateUrl: './admin.login.component.html',
  styleUrls: ['./admin.login.component.css'],
})
export class AdminLoginComponent implements OnInit {
  urlBase = '';
  cabecera: NavMenuComponent;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute,
    header: NavMenuComponent
  ) {
    this.urlBase = baseUrl;
    this.cabecera = header;
  }

  Login() {
    const email = (<HTMLSelectElement>document.getElementById('email')).value;
    const contrasenia = (<HTMLSelectElement>(
      document.getElementById('contrasenia')
    )).value;
    const objeto = {
      Email: email,
      Contrasenia: contrasenia,
      EsSuperAdmin: false,
    };
    this.http
      .post<any>(this.urlBase + '/Admin/Login', objeto, httpOptions)
      .subscribe(
        (result) => {
          sessionStorage.setItem('token', result.mensaje);
          sessionStorage.setItem('email', email);
          this.IrAdminBienvenida();
        },
        (error) => {
          ProcesarRespuesta(error.error);
        }
      );
  }

  IrAdminBienvenida() {
    this.ruta.navigateByUrl('/AdminBienvenida');
  }

  ngOnInit(): void {}
}
