import { Component } from '@angular/core';

@Component({
  selector: 'Bienvenida',
  templateUrl: './bienvenida.component.html',
})
export class BienvenidaComponent {
    
    GuardarData(variable:string){
        sessionStorage.setItem("data", variable)
    }
}