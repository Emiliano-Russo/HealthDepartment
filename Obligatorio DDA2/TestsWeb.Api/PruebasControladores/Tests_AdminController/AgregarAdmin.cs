using Entidades;
using Interfaces;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_AdminController
{
    [TestClass]
    public partial class UnitTest_AdminController
    {
        private Admin adminCorrecto;
        private Admin adminDatosIncorrectos;
        private Mock<ISistema> mock;
        private string token;
        private ConfiguracionHTTP configurador;

        [TestInitialize]
        public void Inicializar()
        {
            mock = new Mock<ISistema>();
            configurador = new ConfiguracionHTTP();
            adminCorrecto = DatosGlobalesAdmin.GetAdminCorrecto();
            adminDatosIncorrectos = DatosGlobalesAdmin.GetAdminIncorrecto();
            token = "AX8";
            mock.Setup(sistema => sistema.ExisteSesionSuperAdmin(token))
               .Returns(true);
        }

        [TestMethod]
        public void AgregarAdmin_AdminCorrecto_AdminRegistrado()
        {
            mock.Setup(sistema => sistema.AgregarAdmin(adminCorrecto));          
            AdminController adminController = new AdminController(mock.Object);

            configurador.ConfigurarHttpResponse(adminController);
            JsonResult resultado = adminController.AgregarAdmin(adminCorrecto,token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = "Admin Registrado";
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void AgregarAdmin_AdminIncorrecto_DatosIncorrectos()
        {
            Exception excepcionAdmin = new ExcepcionDatosAdmin("Datos Admin Incorrectos");
            mock.Setup(sistema => sistema.AgregarAdmin(adminDatosIncorrectos)).Throws(excepcionAdmin);
            AdminController adminController = new AdminController(mock.Object);
            configurador.ConfigurarHttpResponse(adminController);

            JsonResult resultado = adminController.AgregarAdmin(adminDatosIncorrectos,token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = excepcionAdmin.Message;
            Assert.AreEqual(esperado, mensaje);
        }

    }
}
