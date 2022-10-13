using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void GetPlayList_IdExistente_Identicas()
        {
            Playlist playlist = datosGlobalesMusica.CrearPlayListDormir();
            int id = repositorio.RegistrarPlaylist(playlist);
            Playlist resultado = repositorio.GetPlayList(id);
            bool mismosAtributos = opMusica.MismosAtributos(playlist, resultado);
            Assert.IsTrue(mismosAtributos);
        }

    }
}
