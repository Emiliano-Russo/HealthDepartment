using Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace TestsValidaciones
{
    public partial class Validacion
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_PacienteNull_Excepcion()
        {
            validaciones.ValidarFormatoPaciente(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_SinRegistrarPsicologos_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_ApellidoVacio_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Apellido = "";
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_ApellidoNull_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Apellido = null;
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_PacienteEmailVacio_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Email = "";
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_PacienteEmailNull_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Email = null;
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_FechaNacimientoAlFuturo_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.FechaNacimiento = new DateTime(DateTime.Now.Year + 1, 5, 5);
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_NroCelularNull_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.NumeroCelular = null;
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_NroCelularVacio_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.NumeroCelular = "";
            validaciones.ValidarFormatoPaciente(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_NroCelularTieneLetras_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.NumeroCelular = "54543asd5454";
            validaciones.ValidarFormatoPaciente(paciente);
        }
    }
}
