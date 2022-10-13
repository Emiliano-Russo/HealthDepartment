using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {

        [TestMethod]
        public void GetTodasLasPlayList_TraeTodasPlaylists()
        {
            Playlist playList = datosGlobalesMusica.CrearPlayListDormir();
            List<Playlist> esperado = new List<Playlist>();
            esperado.Add(playList);
            repositorio.RegistrarPlaylist(playList);
            List<Playlist> resultado = repositorio.GetTodasLasPlayLists();
            bool mismosAtributos = opMusica.MismaLista(esperado, resultado);
            Assert.IsTrue(mismosAtributos);
        }
    }
}
