using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio_DDA2.Controllers;
using System;
using Moq;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Excepciones;
using LogicaNegocio;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_AdminController
{
    public partial class UnitTest_AdminController
    {
        [TestMethod]
        public void Login_AdminExistente_LoginExistoso()
        {
            mock.Setup(sistema => sistema.IniciarSesion(adminCorrecto))
                .Returns(token);
            AdminController adminController = new AdminController(mock.Object);
            configurador.ConfigurarHttpResponse(adminController);

            JsonResult resultado = adminController.Login(adminCorrecto);
            string mensaje = (((RespuestaJson)resultado.Value).Mensaje).ToString();
            string esperado = token;
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void Login_AdminNoExistente_LoginIncorrecto()
        {
            Exception excepcionAdmin = new ExcepcionDatosAdmin("Admin incorrecto");            
            AdminController adminController = new AdminController(mock.Object);
            configurador.ConfigurarHttpResponse(adminController);

            mock.Setup(sistema => sistema.IniciarSesion(adminDatosIncorrectos)).Throws(excepcionAdmin);
            JsonResult resultado = adminController.Login(adminDatosIncorrectos);
            string mensaje = (((RespuestaJson)resultado.Value).Mensaje).ToString();
            string esperado = excepcionAdmin.Message;
            Assert.AreEqual(esperado, mensaje);
        }
    }
}
