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
        public void RegistrarPsicologo_RegistrarPsicologoCorrecto_PsicologoGuardado()
        {
            Psicologo psicologo = new Psicologo();
            mock.Setup(sistema => sistema.AltaPsicologo(psicologo));
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.RegistrarPsicologo(psicologo, this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = "Psicologo guardado";
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void RegistrarPsicologo_RegistrarPsicologoIncorrecto_NoEsPosibleRegistrar()
        {
            Psicologo psicologo = new Psicologo();
            Exception excepcionPsicologo = new ExcepcionPsicologia("Psicologo datos incorrectos");
            mock.Setup(sistema => sistema.AltaPsicologo(psicologo)).Throws(excepcionPsicologo);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.RegistrarPsicologo(psicologo, this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = excepcionPsicologo.Message;
            Assert.AreEqual(esperado, mensaje);
        }
    }
}
