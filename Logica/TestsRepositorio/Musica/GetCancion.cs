using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void GetCancion_DatosCorrectos_SinExpeciones()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            List<int> idsPlayList = datosGlobalesMusica.GetPlayListIDRegistradasEn();
            repositorio.AltaCancion(cancion, idsPlayList);
            Cancion cancionAComparar = repositorio.GetCancion(cancion.Titulo, cancion.Autor);          
            bool cancionesIguales = opMusica.MismosAtributos(cancion, cancionAComparar);
            Assert.IsTrue(cancionesIguales);
        }

    }
}
