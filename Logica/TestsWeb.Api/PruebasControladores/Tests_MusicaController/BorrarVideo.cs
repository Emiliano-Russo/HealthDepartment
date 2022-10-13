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
        public void BorrarVideo_IdExistente_Ok()
        {
            int idVideo = 1;
            mock.Setup(sistema => sistema.BajaVideo(idVideo));
            MusicaController musicaController = new MusicaController(mock.Object);
            JsonResult resultado = musicaController.BorrarVideo(idVideo, this.token);
            RespuestaJson resul = (RespuestaJson)resultado.Value;
            string esperado = "Video Borrado";
            Assert.AreEqual(esperado, resul.Mensaje);
        }

        [TestMethod]
        public void BorrarVideo_IdNoExistente_NoSeBorra()
        {
            int idVideo = 777;
            string mensajeError = "ID video no encontrado";
            mock.Setup(sistema => sistema.BajaVideo(idVideo)).
                Throws(new ExcepcionMusica(mensajeError));
            MusicaController musicaController = new MusicaController(mock.Object);
            JsonResult resultado = musicaController.BorrarVideo(idVideo, this.token);
            RespuestaJson resul = (RespuestaJson)resultado.Value;
            Assert.AreEqual(mensajeError, resul.Mensaje);
        }
        
    }
}
