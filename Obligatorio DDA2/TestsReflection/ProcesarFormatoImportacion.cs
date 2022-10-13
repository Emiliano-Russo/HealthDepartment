using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;
using Relfection.Interfaces;
using System.Collections.Generic;

namespace TestsReflection
{
    [TestClass]
    public class Reflection
    {
        const string ubicacionArchivo = "C:/FormatosArchivos/ejemploJson.json";

        [TestMethod]
        public void ProcesarFormatoImportacion_datosExistentes_SinExcepcion()
        {
            IMenuImportaciones menu = new MenuImportaciones();
            GaleriaMusical galeria = menu.ProcesarFormatoImportacion(ubicacionArchivo, "ProcesadorJSON");
            bool galeriaVacia = galeria == null;
            Assert.IsFalse(galeriaVacia);
        }

        [TestMethod]
        public void DevolverNombreImportadores_SinExcepcion()
        {
            IMenuImportaciones menu = new MenuImportaciones();
            menu.DevolverNombresImportadores();
        }
    }
}
