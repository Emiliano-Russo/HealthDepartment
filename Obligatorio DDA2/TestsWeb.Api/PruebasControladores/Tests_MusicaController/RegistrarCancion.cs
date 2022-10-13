using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using LogicaNegocio.Excepciones;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {
        [TestMethod]
        public void RegistrarCancion_RegistrarCancionCorrecta_CancionGuardada()
        {
            mock.Setup(sistema => sistema.AltaCancion(cancionEstandar));
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);

            JsonResult resultado = musicaController.RegistrarCancion(cancionEstandar,this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = "Cancion guardada";
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void RegistrarCancion_RegistrarCancionIncorrecta_DatosIncorrectos()
        {
            Exception excepcionMusica = new ExcepcionMusica("Cancion datos incorrectos");
            mock.Setup(sistema => sistema.AltaCancion(cancionEstandar)).Throws(excepcionMusica);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);

            JsonResult resultado = musicaController.RegistrarCancion(cancionEstandar,this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = excepcionMusica.Message;
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void RegistrarCancion_TokenIncorrecto_SinAutorizacion()
        {
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);

            JsonResult resultado = musicaController.RegistrarCancion(cancionEstandar, "asd");
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = "No existe la sesion";
            Assert.AreEqual(esperado, mensaje);
        }


    }
}
