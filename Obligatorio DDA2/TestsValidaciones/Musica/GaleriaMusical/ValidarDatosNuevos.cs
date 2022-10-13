using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;
using Reflection.Excepciones;
using Relfection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsValidaciones
{
    public partial class Validacion
    {
       
        [TestMethod]
        [ExpectedException(typeof(ExcepcionMenuImportacion))]
        public void AgregarGaleria_RutaIncorrecta_Excepcion()
        {
            string ruta = "C:\\FormatosArchivos\\example74.json";
            string tipoArchivo = "ProcesadorJSON";
            IMenuImportaciones menuImportaciones = new MenuImportaciones();
            GaleriaMusical galeria = menuImportaciones.ProcesarFormatoImportacion(ruta, tipoArchivo);
            validaciones.ValidarDatosNuevos(galeria);
        }
    }
}
