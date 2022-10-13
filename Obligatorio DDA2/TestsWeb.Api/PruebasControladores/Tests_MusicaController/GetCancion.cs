using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidades.OperacionesEntidades;
using Microsoft.AspNetCore.Http;
using System.Net;
using LogicaNegocio.Excepciones;
using Web.Api.Administracion;
using Web.Api.Entidades.Presentacion;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {

        [TestMethod]
        public void GetCancion_CancionExistente_RetornoCorrecto()
        {
            Cancion modelo = cancionEstandar;
            modelo.Duracion = 8000;
                mock.Setup(sistema => sistema.GetCancion(cancionEstandar.Titulo, cancionEstandar.Autor)).Returns
                (modelo);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json =  musicaController.GetCancion(cancionEstandar.Titulo, cancionEstandar.Autor);
            CancionExhibicion cancion = (CancionExhibicion)((RespuestaJson)json.Value).Mensaje;
            bool mismosAtributos = opMusica.MismosAtributos(cancionEstandar, cancion);
            Assert.IsTrue(mismosAtributos);
            Assert.IsTrue(cancion.CategoriasMusicales.Count > 0);
        }

        [TestMethod]
        public void GetCancion_CancionExistente2_RetornoCorrecto()
        {
            mock.Setup(sistema => sistema.GetCancion(cancionEstandar.Titulo, cancionEstandar.Autor)).Returns
                (this.cancionEstandar);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.GetCancion(cancionEstandar.Titulo, cancionEstandar.Autor);
            CancionExhibicion cancion = (CancionExhibicion)((RespuestaJson)json.Value).Mensaje;
            bool mismosAtributos = opMusica.MismosAtributos(cancionEstandar, cancion);
            Assert.IsTrue(mismosAtributos);
            Assert.IsTrue(cancion.CategoriasMusicales.Count > 0);
        }

        [TestMethod]
        public void GetCancion_CancionNoExistente_Excepcion()
        {
            Exception excepcionMusica = new ExcepcionMusica("Cancion datos incorrectos");
            mock.Setup(sistema => sistema.GetCancion("asd", null)).Throws(excepcionMusica);
            MusicaController musicaControler = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaControler);
            JsonResult json = musicaControler.GetCancion("asd", null);
            string mensaje = ((RespuestaJson)json.Value).Mensaje.ToString();
            string esperado = excepcionMusica.Message;
            Assert.AreEqual(esperado, mensaje);
        }
        
    }
 
}
