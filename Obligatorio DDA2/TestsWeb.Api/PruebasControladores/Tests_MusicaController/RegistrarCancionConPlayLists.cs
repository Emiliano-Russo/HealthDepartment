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
using Web.Api.Entidades;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {
        [TestMethod]
        public void RegistrarCancionConPlayLists_DatosCorrectos_MensajeEsperado()
        {
            List<int> listaIdsPlayList = new List<int>();
            mock.Setup(sistema => sistema.AltaCancion(cancionEstandar, listaIdsPlayList));
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);

            CancionPlayList datos = new CancionPlayList();
            datos.Cancion = cancionEstandar;
            datos.IdPlayLists = listaIdsPlayList;
            JsonResult json = musicaController.RegistrarCancionConPlayLists(datos, this.token);
            string resultado = ((RespuestaJson)json.Value).Mensaje.ToString();
            string esperado = "Cancion Registrada!";
            Assert.AreEqual(esperado, resultado);
        }  
        
        [TestMethod]
        public void RegistrarCancionConPlayLists_DatosCorrectos_ExcepcionMensaje()
        {
            ExcepcionMusica excepcionMusica = new ExcepcionMusica("Datos Incorrectos");
            List<int> listaIdsPlayList = null;
            mock.Setup(sistema => sistema.AltaCancion(cancionEstandar, listaIdsPlayList))
                .Throws(excepcionMusica);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);

            CancionPlayList datos = new CancionPlayList();
            datos.Cancion = cancionEstandar;
            datos.IdPlayLists = listaIdsPlayList;
            JsonResult json = musicaController.RegistrarCancionConPlayLists(datos, this.token);
            string resultado = ((RespuestaJson)json.Value).Mensaje.ToString();
            string esperado = excepcionMusica.Message;
            Assert.AreEqual(esperado, resultado);
        }
    }
}
