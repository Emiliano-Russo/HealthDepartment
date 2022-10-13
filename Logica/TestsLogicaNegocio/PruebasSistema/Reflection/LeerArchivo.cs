using Entidades;
using Interfaces;
using LogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;
using Reflection.Excepciones;
using Relfection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsLogicaNegocio
{
    
    public partial class SistemaTest
    {
        [TestMethod]
        public void AgregarGaleria_JsonCorrecto_SinExpeciones()
        {
            string ruta = "C:\\FormatosArchivos\\ejemploJson.json";
            string tipoArchivo = "ProcesadorJSON";
            sistema.LeerArchivo(ruta, tipoArchivo);
            IMenuImportaciones importacion = new MenuImportaciones();
            GaleriaMusical galeria = importacion.ProcesarFormatoImportacion(ruta, tipoArchivo);
            GaleriaMusical galeriaGuardada = sistema.GetGaleriaMusical(galeria.CategoriaMusical);
            bool tienenMismosAtributos = opMusica.MismosAtributos(galeria, galeriaGuardada);
            Assert.IsTrue(tienenMismosAtributos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMenuImportacion))]
        public void AgregarGaleria_RutaIncorrecta_Excepcion()
        {
            string ruta = "C:\\FormatosArchivos\\example74.json";
            string tipoArchivo = "ProcesadorJSON";
            sistema.LeerArchivo(ruta, tipoArchivo);
            
        }
    }
}
