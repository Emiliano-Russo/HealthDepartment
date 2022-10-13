using Entidades;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Repositorio.RepositorioBDD;
using System.Collections.Generic;
using Utilidades;
using Utilidades.OperacionesEntidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void AltaCancion_CancionDormir_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            repositorio.AltaCancion(cancion);
        }

        [TestMethod]
        public void AltaCancion_DatosValidos_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            List<int> listaPlaylist = datosGlobalesMusica.GetPlayListIDRegistradasEn();
            repositorio.AltaCancion(cancion, listaPlaylist);
        }

        [TestMethod]
        public void AltaCancion_CancionMeditar_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            repositorio.AltaCancion(cancion);
        }

    }
}
