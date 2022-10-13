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
        public void PedirCita_PacienteValido_CitaAgenadada()
        {
            Paciente paciente = new Paciente();
            Cita cita = new Cita();
            mock.Setup(sistema => sistema.AgendarCita(paciente))
                .Returns(cita);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult json = psicologiaController.PedirCita(paciente);
            Cita resultado = (Cita)((RespuestaJson)json.Value).Mensaje;
            bool iguales = op.MismosAtributos(resultado, cita);
            Assert.IsTrue(iguales);
        }

        [TestMethod]
        public void PedirCita_PacienteInvalido_NoEsPosibleCita()
        {
            Paciente paciente = new Paciente();
            Exception excepcionPsicologo = new ExcepcionPsicologia("Datos Incorrectos del Paciente");
            mock.Setup(sistema => sistema.AgendarCita(paciente)).Throws(excepcionPsicologo);
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            configurador.ConfigurarHttpResponse(psicologiaController);

            JsonResult resultado = psicologiaController.PedirCita(paciente);
            string mensaje = ((RespuestaJson)resultado.Value).Mensaje.ToString();
            string esperado = excepcionPsicologo.Message;
            Assert.AreEqual(esperado, mensaje);
        }
    }
}
