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
        public void GetTodasLasCanciones_ListaVacia()
        {
            List<Cancion> canciones = new List<Cancion>();
            mock.Setup(sistema => sistema.GetTodasLasCanciones()).Returns(canciones);
            MusicaController musicaController = new MusicaController(mock.Object);
            JsonResult resultado = musicaController.GetTodasLasCanciones();
            List<Cancion> resultadoCanciones = (List<Cancion>)((RespuestaJson)resultado.Value).Mensaje;
            Assert.IsTrue(resultadoCanciones.Count == 0);
        }
        
    }
}
