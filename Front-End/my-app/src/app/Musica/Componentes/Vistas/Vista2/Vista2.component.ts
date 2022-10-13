import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';


@Component({
  selector: 'Vista2',
  templateUrl: './Vista2.component.html',
})
export class PlayListComponent implements OnInit {
  urlBase = '';
  elementosVista2: any[] = [];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
  ) {
    this.urlBase = baseUrl; 
  }

  ngOnInit(): void {
    this.GetElementosVista2();
  }

  GetElementosVista2() {
    this.http
      .get<any>(this.urlBase + '/Vista2')
      .subscribe(
        (result) => {
          this.elementosVista2 = result.mensaje
        }
      );
  }
}