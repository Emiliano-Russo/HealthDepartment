using Interfaces;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using Repositorio.Repositorio.RepositorioBDD;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades.OperacionesEntidades;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_PsicologiaController
{
    public partial class UnitTest_PsicologiaController
    {

        private ISistema sistema;
        private Mock<ISistema> mock;
        private string token;
        private RepositorioBDD repositorio;
        private OperacionesPsicologia op;
        private ConfiguracionHTTP configurador;

        [TestInitialize]
        public void Inicializar()
        {
            mock = new Mock<ISistema>();
            configurador = new ConfiguracionHTTP();
            this.token = "AX8";
            mock.Setup(sistema => sistema.ExisteSesionAdmin(token)).Returns(true);
            mock.Setup(sistema => sistema.ExisteSesionSuperAdmin(token)).Returns(true);
            var opciones = new DbContextOptionsBuilder<EntidadesContexto>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            this.repositorio = new RepositorioBDD(opciones);
            this.op = new OperacionesPsicologia(repositorio);
        }

        [TestCleanup]
        public void Limpiar()
        {
            repositorio.BorrarTodosLosDatos();
        }

        [TestMethod]
        public void EliminarPsicologo_PsicologoExistente_PsicologoEliminado()
        {
            mock.Setup(sistema => sistema.BajaPsicologo(1));
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.EliminarPsicologo(1, this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = "Psicologo eliminado";
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void EliminarPsicologo_PsicologoInexistente_PsicologoNoExistente()
        {
            Exception excepcionPsicologo = new ExcepcionPsicologia("No existe psicologo");
            mock.Setup(sistema => sistema.BajaPsicologo(1)).Throws(excepcionPsicologo);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.EliminarPsicologo(1, this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = excepcionPsicologo.Message;
            Assert.AreEqual(esperado, mensaje);
        }

        [TestMethod]
        public void EliminarPsicologo_IndexNegativo_Error()
        {
            Exception excepcionPsicologo = new ExcepcionPsicologia("El Index es negativo");
            mock.Setup(sistema => sistema.BajaPsicologo(-1)).Throws(excepcionPsicologo);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.EliminarPsicologo(-1, this.token);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = excepcionPsicologo.Message;
            Assert.AreEqual(esperado, mensaje);
        }
    }
}
