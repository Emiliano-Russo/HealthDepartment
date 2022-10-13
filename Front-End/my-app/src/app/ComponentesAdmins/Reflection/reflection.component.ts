import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProcesarRespuesta } from 'src/app/Apoyo/ManejoRespuesta';

@Component({
    selector: 'reflection',
    templateUrl: './reflection.component.html',
    styleUrls: ['./reflection.component.css']
  })
  export class ReflectionComponent implements OnInit {
    nombreArchivo = "";
    urlBase = "";
    listaProcesadores = [];
    procesadorSeleccionado = "";
    archivo:any = undefined;

    constructor(
        private http:HttpClient,
        @Inject('BASE_URL') private baseUrl:string
    ){
        
    }

    ngOnInit(): void{
        this.urlBase = this.baseUrl;
        this.GetTodasLasImportaciones();
    }

    GetTodasLasImportaciones(){
        this.http.get<any>(this.urlBase + "/Musica/GetTodasLasImportaciones")
        .subscribe(result => {
            this.listaProcesadores = result;
        }, error => {
            ProcesarRespuesta(error.error);
        })
    }

    ProcesadorSeleccionado(procesador:string){
        this.procesadorSeleccionado = procesador;
        console.log(this.procesadorSeleccionado);
    }

    ArchivoSeleccionado(event:any){
        this.archivo = event.target.files[0];
    }

    EnviarArchivo(){
        const httpOptions = {
            headers: new HttpHeaders ({
                'token': sessionStorage.getItem("token") + "",
                'tipoArchivo': this.procesadorSeleccionado
            })
        }

        if (this.archivo) {

            this.nombreArchivo = this.archivo.name;

            const datosForm = new FormData();

            datosForm.append("archivo", this.archivo);

            this.http.post(this.urlBase + "/Musica/SubirArchivo", datosForm, httpOptions)
            .subscribe(result => {
                ProcesarRespuesta(result);
            }, error => {
                ProcesarRespuesta(error.error);
            });
        } 
    
    }
}