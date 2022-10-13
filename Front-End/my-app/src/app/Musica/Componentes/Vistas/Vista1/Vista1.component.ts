import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';


@Component({
  selector: 'Vista1',
  templateUrl: './Vista1.component.html',
})
export class PlayListComponent implements OnInit {
  urlBase = '';
  elementosVista1: any[] = [];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
  ) {
    this.urlBase = baseUrl; 
  }

  ngOnInit(): void {
    this.GetElementosVista1()
  }

  GetElementosVista1() {
    this.http
      .get<any>(this.urlBase + '/Vista1')
      .subscribe(
        (result) => {
          this.elementosVista1 = result.mensaje
        }
      );
  }
}