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
        public void GetTodosLosVideos_Ok()
        {
            List<Video> videos = new List<Video>();
            mock.Setup(sistema => sistema.GetTodosLosVideos()).Returns(videos);
            MusicaController musicaController = new MusicaController(mock.Object);
            JsonResult resultado = musicaController.GetTodosLosVideos();
            List<Video> resultadoVideos = (List<Video>)((RespuestaJson)resultado.Value).Mensaje;
            Assert.IsTrue(resultadoVideos.Count == 0);
        }
        
    }
}
