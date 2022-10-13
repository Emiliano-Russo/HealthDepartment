using Entidades;
using Entidades.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void RegistrarGaleriaMusical_GaleriaSinDatos_SinExcepcion()
        {
            GaleriaMusical galeria = new GaleriaMusical
            {
                Canciones = new List<Cancion>(),
                PlayLists = new List<Playlist>(),
                Videos = new List<Video>(),
                CategoriaMusical = CategoriaMusical.Cuerpo
            };
            repositorio.RegistrarGaleriaMusical((galeria));
        }
    }
}
