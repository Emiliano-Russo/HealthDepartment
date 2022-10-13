using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetCancion_DatosCorrectos_SinExpeciones()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            List<int> idsPlayList = datosGlobalesMusica.GetPlayListIDRegistradasEn();
            sistema.AltaCancion(cancion, idsPlayList);
            Cancion cancionAComparar = sistema.GetCancion(cancion.Titulo, cancion.Autor);
            Assert.AreEqual(cancion, cancionAComparar);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetCancion_TituloNull_Expecion()
        {
           sistema.GetCancion(null, "Felipe");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetCancion_AutorNull_Expecion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            List<int> idsPlayList = datosGlobalesMusica.GetPlayListIDRegistradasEn();
            sistema.AltaCancion(cancion, idsPlayList);
            Cancion cancionAComparar = sistema.GetCancion(cancion.Titulo, null);
            Assert.AreEqual(cancion, cancionAComparar);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetCancion_AutorVacio_Expecion()
        {
            sistema.GetCancion("Flores", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetCancion_TituloVacio_Expecion()
        {
            sistema.GetCancion("", "Rodrigo");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetCancion_GetCancionSinAlta_Expecion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            sistema.GetCancion(cancion.Titulo, cancion.Autor);
        }
    }
}
