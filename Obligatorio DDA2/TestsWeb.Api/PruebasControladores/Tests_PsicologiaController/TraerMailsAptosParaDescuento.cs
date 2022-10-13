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
        public void TraerMailsAptosParaDescuento_Ok()
        {
            mock.Setup(sistema => sistema.TraerMailsAptosParaDescuento()).Returns(new List<string>());
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            JsonResult jsonResult = psicologiaController.TraerMailsAptosParaDescuentos();
            List<string> listaMailsResultado = (List<string>)((RespuestaJson)jsonResult.Value).Mensaje;
            Assert.IsTrue(listaMailsResultado.Count == 0);
        }
    }
}
