using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void RegistrarGaleriaMusical_GaleriaSinDatos_SinExcepcion()
        {
            GaleriaMusical galeria = new GaleriaMusical
            {
                Canciones = new List<Cancion>(),
                PlayLists = new List<Playlist>(),
                CategoriaMusical = CategoriaMusical.Cuerpo
            };
            sistema.RegistrarGaleriaMusical((galeria));
        }
    }
}
