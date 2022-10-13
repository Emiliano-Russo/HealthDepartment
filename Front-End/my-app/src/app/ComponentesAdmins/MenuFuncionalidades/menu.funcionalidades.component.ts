import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'menu_funcionalidades',
  templateUrl: './menu.funcionalidades.component.html',
  styleUrls: ['./menu.funcionalidades.component.css'],
})
export class MenuFuncionalidadesComponent implements OnInit {
  urlBase = '';
  categoriasPsicologicas: string[] = [];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
  }
  ngOnInit(): void {}

  IrAltaContenido() {
    this.ruta.navigateByUrl('/SeccionAltaCancionOVideo');
  }
  IrBajaContenido() {
    this.ruta.navigateByUrl('/BajaContenido');
  }
  IrAltaPsicologo() {
    this.ruta.navigateByUrl('/AltaPsicologo');
  }
  IrModificarPsicologo() {
    this.ruta.navigateByUrl('/ListaPsicologosModificables');
  }
  IrBajaPsicologo() {
    this.ruta.navigateByUrl('/BajaPsicologo');
  }
  IrAgregarAdmin() {
    this.ruta.navigateByUrl('/AgregarAdmin');
  }
  IrDescuentoEmails() {
    this.ruta.navigateByUrl('/DescuentoEmails');
  }
  IrRegistrarPlaylist() {
    this.ruta.navigateByUrl('/RegistrarPlaylist');
  }

  IrReflection() {
    this.ruta.navigateByUrl('/Reflection');
  }
}
