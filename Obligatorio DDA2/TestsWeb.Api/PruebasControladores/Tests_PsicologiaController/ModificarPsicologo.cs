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
        public void ModificarPsicologo_PsicologoExistente_PsicologoModificado()
        {
            Psicologo psicologo = new Psicologo();
            psicologo.ID = 1;
            mock.Setup(sistema => sistema.ModificarPsicologo(1, psicologo));
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.ModificarPsicologo(psicologo, this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = "Psicologo modificado";
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void ModificarPsicologo_IndexNegativo_PsicologoNoExistente()
        {
            Psicologo psicologo = new Psicologo();
            psicologo.ID = -1;
            Exception excepcionPsicologo = new ExcepcionPsicologia("No existe psicologo");
            mock.Setup(sistema => sistema.ModificarPsicologo(-1, psicologo)).Throws(excepcionPsicologo);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.ModificarPsicologo(psicologo, this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = excepcionPsicologo.Message;
            Assert.AreEqual(esperado, mensaje);
        }
    }
}
