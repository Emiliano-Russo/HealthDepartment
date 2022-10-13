import { Component, DoCheck } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { BienvenidaComponent } from '../Bienvenida/bienvenida.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements DoCheck {
  tokenNoNull: boolean = false;
  emailAdmin: string = "nombreAdmin";

  ngDoCheck(): void {
    this.ExisteAdminLogeado();
  }

  ExisteAdminLogeado(){
    let token = sessionStorage.getItem('token');
    this.tokenNoNull =  token != null;
    let email = sessionStorage.getItem('email');
    if(email != null){
      this.emailAdmin = email;
    }
  }
}
