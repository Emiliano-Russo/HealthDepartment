using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesImportaciones.IMenuImportaciones
{
    public interface IMenuImportaciones
    {
        public List<string> DevolverNombresImportadores();
        public GaleriaMusical ProcesarFormatoImportacion(string direccionArchivo, string tipoImportador);
    }
}
