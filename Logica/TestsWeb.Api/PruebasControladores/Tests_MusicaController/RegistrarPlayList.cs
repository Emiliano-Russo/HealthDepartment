using Entidades;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidades.OperacionesEntidades;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {
        [TestMethod]
        public void RegistrarPlayList_DatosCorrectos_IdEsperado()
        {
            mock.Setup(sistema => sistema.RegistrarPlaylist(this.playlistEstandar)).
                Returns(1);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.RegistrarPlayList(this.playlistEstandar, token);
            string resultado = ((RespuestaJson)json.Value).Mensaje.ToString();
            string esperado = "1";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void RegistrarPlayList_DatosIncorrectos_ExcepcionMensaje()
        {
            ExcepcionMusica ex = new ExcepcionMusica("Datos incorrectos");
            mock.Setup(sistema => sistema.RegistrarPlaylist(this.playlistEstandar))
                .Throws(ex);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.RegistrarPlayList(this.playlistEstandar, this.token);
            string resultado = ((RespuestaJson)json.Value).Mensaje.ToString();
            string esperado = ex.Message;
            Assert.AreEqual(esperado, resultado);
        }
        
    }
}
