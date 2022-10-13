using Entidades;
using Entidades.Entidades;
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
        public void RegistrarVideo_DatosCorrectos_Ok()
        {
            int idVideo = 1;
            Video video = new Video();
            video.ID = idVideo;

            mock.Setup(sistema => sistema.AltaVideo(video)).Returns(idVideo);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.RegistrarVideo(video, token);
            int resultado = (int)(((RespuestaJson)json.Value).Mensaje);
            Assert.AreEqual(idVideo, resultado);
        }


        [TestMethod]
        public void RegistrarVideo_DatosIncorrectos_MensajeExcepcion()
        {
            ExcepcionMusica ex = new ExcepcionMusica("Datos incorrectos");
            int idVideo = 1;
            Video video = new Video();
            video.ID = idVideo;
            mock.Setup(sistema => sistema.AltaVideo(video)).Throws(ex);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.RegistrarVideo(video, this.token);
            string resultado = ((RespuestaJson)json.Value).Mensaje.ToString();
            string esperado = ex.Message;
            Assert.AreEqual(esperado, resultado);
        }
        
    }
}
