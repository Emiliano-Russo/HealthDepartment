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

namespace TestsWeb.Api.PruebasControladores.Tests_PsicologiaController
{
    public partial class UnitTest_PsicologiaController
    {
        [TestMethod]
        public void GetTodasLosPsicologos_GetTodosLosPsicologos_DevuelvoPsicologos()
        {
            List<Psicologo> listaPsicologo = new List<Psicologo>();
            mock.Setup(sistema => sistema.GetTodosLosPsicologos()).Returns(listaPsicologo);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.GetTodosLosPsicologos(this.token);
            List<Psicologo> resultadoPsicologo = (List<Psicologo>)((RespuestaJson)resultado.Value).Mensaje;
            Assert.AreEqual(resultadoPsicologo, listaPsicologo);
        }
    }
}
