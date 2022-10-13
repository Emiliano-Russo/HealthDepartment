using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using System.Collections.Generic;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetTodasLasPlayList_TraeTodasPlaylists()
        {
            Playlist playList = datosGlobalesMusica.CrearPlayListDormir();
            List<Playlist> esperado = new List<Playlist>(); 
            esperado.Add(playList);
            sistema.RegistrarPlaylist(playList);
            List<Playlist> resultado = sistema.GetTodasLasPlayList();
            bool mismosAtributos = opMusica.MismaLista(esperado, resultado);
            Assert.IsTrue(mismosAtributos);
        }
    }
}
