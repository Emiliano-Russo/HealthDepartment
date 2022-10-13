import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';


@Component({
  selector: 'Vista3',
  templateUrl: './Vista3.component.html',
})
export class PlayListComponent implements OnInit {
  urlBase = '';
  elementosVista3: any[] = [];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
  ) {
    this.urlBase = baseUrl; 
  }

  ngOnInit(): void {
    this.GetElementosVista3();
  }

  GetElementosVista3() {
    this.http
      .get<any>(this.urlBase + '/Vista3')
      .subscribe(
        (result) => {
          this.elementosVista3 = result.mensaje
        }
      );
  }
}