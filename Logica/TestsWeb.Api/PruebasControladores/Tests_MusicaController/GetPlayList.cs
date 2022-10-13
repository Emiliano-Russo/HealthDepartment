using Entidades;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
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
        public void GetPlayList_1_Iguales()
        {
            Playlist playlist = new Playlist();
            playlist.AgregarCategoria(CategoriaMusical.Musica);
            mock.Setup(sistema => sistema.GetPlayList(1)).
                Returns(playlist);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.GetPlayList(1);
            PlaylistExhibicion resultado = (PlaylistExhibicion)((RespuestaJson)json.Value).Mensaje;
            Assert.IsTrue(resultado.Canciones.Count == 0
                && resultado.ListaCategorias[0] == "Musica");
            bool mismosAtributos = opMusica.MismosAtributos(playlist, resultado);
            Assert.IsTrue(mismosAtributos);
        }

        [TestMethod]
        public void GetPlayList_Negativo_Error()
        {
            ExcepcionMusica excepcion = new ExcepcionMusica("No se aceptan valores negativos");
            mock.Setup(sistema => sistema.GetPlayList(-1)).Throws(excepcion);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.GetPlayList(-1);
            string resultado = ((RespuestaJson)json.Value).Mensaje.ToString();
            string esperado = excepcion.Message;
            Assert.AreEqual(esperado, resultado);
        }
    }
}
