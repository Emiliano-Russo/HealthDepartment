import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient} from '@angular/common/http';


@Component({
  selector: 'Vista4',
  templateUrl: './Vista4.component.html',
})
export class PlayListComponent implements OnInit {
  urlBase = '';
  elementosVista4: any[] = [];

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
  ) {
    this.urlBase = baseUrl; 
  }

  ngOnInit(): void {
    this.GetElementosVista4();
  }

  GetElementosVista4() {
    this.http
      .get<any>(this.urlBase + '/Vista4')
      .subscribe(
        (result) => {
          this.elementosVista4 = result.mensaje
        }
      );
  }
}