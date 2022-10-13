using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Administracion;
using Web.Api.Entidades.Presentacion;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {
        [TestMethod]
        public void GetTodasLasPlaylist_GetTodasPlaylists_DevuelvoPlaylists()
        {
            List<Playlist> playLists = new List<Playlist>();
            mock.Setup(sistema => sistema.GetTodasLasPlayList()).Returns(playLists);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);

            JsonResult resultado = musicaController.GetTodasLasPlayList();
            List<PlaylistExhibicion> resultadoPlayLists = (List<PlaylistExhibicion>)((RespuestaJson)resultado.Value).Mensaje;
            Assert.IsTrue(resultadoPlayLists.Count == 0);
        }
    }
}
