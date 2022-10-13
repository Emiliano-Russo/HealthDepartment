using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetPlayList_IdExistente_Identicas()
        {
            Playlist playlist = datosGlobalesMusica.CrearPlayListDormir();
            int id = sistema.RegistrarPlaylist(playlist);
            Playlist resultado = sistema.GetPlayList(id);
            bool mismosAtributos = opMusica.MismosAtributos(playlist, resultado);
            Assert.IsTrue(mismosAtributos);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetPlayList_IdInExsitente_Excepcion()
        {
            sistema.GetPlayList(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetPlayList_IdInExsitente2_Excepcion()
        {
            sistema.GetPlayList(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetPlayList_IdInExsitente3_Excepcion()
        {
            sistema.GetPlayList(0);
        }
    }
}
