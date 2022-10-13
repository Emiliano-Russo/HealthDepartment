import { Component, Inject, Injectable, OnInit, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Component({
  selector: 'nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['nav-menu.component.css'],
})
@Injectable()
export class NavMenuComponent implements OnInit {
  urlBase = '';

  @Input() adminLogeado: boolean = false;
  @Input() nombreAdmin: string = 'Nombre Admin';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
  }

  ngOnInit(): void {}
}
