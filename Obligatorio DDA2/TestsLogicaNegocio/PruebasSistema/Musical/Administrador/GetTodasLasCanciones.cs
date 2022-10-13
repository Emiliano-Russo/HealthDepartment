using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;
using Web.Api.Entidades;
using Entidades.Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetTodasLasCanciones_DosCancionesRegistradas_ListaDosCanciones()
        {
            Cancion cancionDormir = DatosGlobalesMusica.CrearCancionDormir();
            Cancion cancionMeditar = DatosGlobalesMusica.CrearCancionMeditar();
            sistema.AltaCancion(cancionDormir);
            sistema.AltaCancion(cancionMeditar);
            List<Cancion> todasLasCanciones = sistema.GetTodasLasCanciones();
            Assert.IsTrue(todasLasCanciones.Contains(cancionDormir));
            Assert.IsTrue(todasLasCanciones.Contains(cancionMeditar));
        }

        [TestMethod]
        public void GetTodasLasCanciones_SinCanciones_ListaVacia()
        {
            List<Cancion> canciones = sistema.GetTodasLasCanciones();
            Assert.IsTrue(canciones.Count == 0);
        }
    }
}
