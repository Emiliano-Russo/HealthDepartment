import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'seccion_alta_cancion_o_video',
  templateUrl: './seccion.alta.cancion.o.video.component.html',
  styleUrls: ['seccion.alta.cancion.o.video.component.css'],
})
export class SeccionAltaCancionOVideoComponent implements OnInit {
  urlBase = '';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private ruta: Router,
    private router: ActivatedRoute
  ) {
    this.urlBase = baseUrl;
  }
  ngOnInit(): void {}

  IrAltaCancion() {
    this.ruta.navigateByUrl('/AltaCancion');
  }

  IrAltaVideo() {
    this.ruta.navigateByUrl('/AltaVideo');
  }
}
