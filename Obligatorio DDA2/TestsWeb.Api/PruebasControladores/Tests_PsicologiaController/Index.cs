using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_PsicologiaController
{
    [TestClass]
    public partial class UnitTest_PsicologiaController
    {
        [TestMethod]
        public void Index_TodasLasProblematicas()
        {
            List<CategoriaDolencia> categoriasDolencias = Enum.GetValues(typeof(CategoriaDolencia)).Cast<CategoriaDolencia>().ToList();
            mock.Setup(sistema => sistema.GetProblematicas()).Returns(categoriasDolencias);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult json = psicologiaController.Index();
            List<CategoriaDolencia> listaResultado = (List<CategoriaDolencia>)((RespuestaJson)json.Value).Mensaje;
            bool iguales = listaResultado.Equals(categoriasDolencias);
            Assert.IsTrue(iguales);
        }
    }
}
