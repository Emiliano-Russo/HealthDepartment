using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using System;
using Utilidades.OperacionesEntidades;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        

        [TestMethod]
        public void AgendarCita_PacienteEstres_UnicoPsicologoRegistrado()
        {
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            int IdPsicologo = opPsicologia.AltaPsicologo(psicologoTrataEstres);
            Cita cita = sistema.AgendarCita(pacienteEstresado);
            Assert.AreEqual(IdPsicologo, cita.IdPsicologo);                      
        }

        [TestMethod]
        public void AgendarCita_PacienteEstres_PrimerPsicologoRegistrado()
        {
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();

            int Id1= opPsicologia.AltaPsicologo(psicologoTrataEstres);
            int Id2 = opPsicologia.AltaPsicologo(psicologoTrataEstres);

            Cita cita = sistema.AgendarCita(pacienteEstresado);
            Assert.AreEqual(Id1, cita.IdPsicologo);
            Assert.AreEqual(cita.NombrePsicologo, psicologoTrataEstres.Nombre);
            Assert.AreNotSame(Id2, cita.IdPsicologo);
        }

        [TestMethod]
        public void AgendarCita_PacienteEstresado_PsicologoTrataEstres()
        {
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            Psicologo psicologoTrataRelaciones = DatosGlobalesPsicologia.GetPsicologoTrataRelaciones();

            int Id1 = opPsicologia.AltaPsicologo(psicologoTrataRelaciones);
            int Id2 = opPsicologia.AltaPsicologo(psicologoTrataEstres);
           
            Cita cita = sistema.AgendarCita(pacienteEstresado);
            Assert.AreEqual(Id2, cita.IdPsicologo);
            Assert.AreEqual(cita.NombrePsicologo, psicologoTrataEstres.Nombre);
            Assert.AreNotSame(Id1, cita.IdPsicologo);
            Assert.IsFalse(Util.EsSabadoODomingo(cita.FechaConsulta));
        }

        [TestMethod]
        public void AgendarCita_PacienteEstres_LugarProximaSemana()
        {
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();

            int id = opPsicologia.AltaPsicologo(psicologoTrataEstres);

            opPsicologia.LLenarLaSemanaDeAgendaCitaPorEstresParaUnPsicologo();
            Cita cita = sistema.AgendarCita(pacienteEstresado);
            bool fechasMismaSemana = Util.FechasEnMismaSemanaEmpezandoElSabado(cita.FechaConsulta, DateTime.Now);
            Assert.IsFalse(fechasMismaSemana);
            Assert.IsFalse(Util.EsSabadoODomingo(cita.FechaConsulta));
        }

        [TestMethod]
        public void AgendarCita_PacienteEstres_UltimoLugarMismaSemana()
        {
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();

            int id = opPsicologia.AltaPsicologo(psicologoTrataEstres);

            opPsicologia.DejarUnLugarEnSemanaDeAgendaCitaPorEstresParaUnPsicologo();
            Cita cita = sistema.AgendarCita(pacienteEstresado);
            bool fechasMismaSemana = Util.FechasEnMismaSemanaEmpezandoElSabado(cita.FechaConsulta, DateTime.Now);

            Assert.IsFalse(Util.EsSabadoODomingo(cita.FechaConsulta));
            Assert.IsTrue(fechasMismaSemana);
        }

        [TestMethod]
        public void AgendarCita_PacienteEstres_DisponibleEsaSemana()
        {
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();

            int Id1 = opPsicologia.AltaPsicologo(psicologoTrataEstres);
            int Id2 = opPsicologia.AltaPsicologo(psicologoTrataEstres);

            opPsicologia.LLenarLaSemanaDeAgendaCitaPorEstresParaUnPsicologo();
            Cita cita = sistema.AgendarCita(pacienteEstresado);
            bool fechasMismaSemana = Util.FechasEnMismaSemanaEmpezandoElSabado(cita.FechaConsulta, DateTime.Now);

            Assert.IsFalse(Util.EsSabadoODomingo(cita.FechaConsulta));
            Assert.IsTrue(fechasMismaSemana);
            Assert.AreEqual(cita.IdPsicologo, Id2);
            Assert.AreNotEqual(Id1, Id2);
        }

        [TestMethod]
        public void AgendarCita_PacienteEstres_ProximaSemana()
        {
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            Psicologo psicologoTrataRelaciones = DatosGlobalesPsicologia.GetPsicologoTrataRelaciones();

            int Id1 = opPsicologia.AltaPsicologo(psicologoTrataRelaciones);
            int Id2 = opPsicologia.AltaPsicologo(psicologoTrataEstres);

            opPsicologia.LLenarLaSemanaDeAgendaCitaPorEstresParaUnPsicologo();
            Cita cita = sistema.AgendarCita(pacienteEstresado);
            bool mismaSemana = Util.FechasEnMismaSemanaEmpezandoElSabado(DateTime.Now, cita.FechaConsulta);

            Assert.IsFalse(Util.EsSabadoODomingo(cita.FechaConsulta));
            Assert.IsFalse(mismaSemana);
            Assert.AreEqual(cita.IdPsicologo, Id2);
            Assert.AreNotEqual(Id1, Id2);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_PacienteNull_Excepcion()
        {
            
            opPsicologia.RegistrarPsicologoEstresEn();
            sistema.AgendarCita(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_SinRegistrarPsicologos_Excepcion()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_ApellidoVacio_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Apellido = "";
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_ApellidoNull_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Apellido = null;
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_PacienteEmailVacio_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Email = "";
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_PacienteEmailNull_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.Email = null;
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_FechaNacimientoAlFuturo_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.FechaNacimiento = new DateTime(DateTime.Now.Year+1,5,5);
            sistema.AgendarCita(paciente);          
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_NroCelularNull_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.NumeroCelular = null;
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_NroCelularVacio_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.NumeroCelular = "";
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AgendarCita_NroCelularTieneLetras_Excepcion()
        {
            opPsicologia.RegistrarPsicologoEstresEn();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            paciente.NumeroCelular = "54543asd5454";
            sistema.AgendarCita(paciente);
        }

        [TestMethod]
        public void AgendarCita_Paciente_LinkVirtualCorrecto()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            psicologo.FormatoConsulta = FormatoConsulta.Virtual;
            sistema.AltaPsicologo(psicologo);
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Cita cita = sistema.AgendarCita(paciente);
            string linkResultado = cita.DireccionConsulta;
            string linkParteEsperada = "https://bettercalm.com.uy/" + linkResultado.Substring(26);
            Assert.AreEqual(linkParteEsperada, linkResultado);
        }

        [TestMethod]
        public void AgendarCita_Paciente_LinkUrbano()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            psicologo.FormatoConsulta = FormatoConsulta.Presencial;
            sistema.AltaPsicologo(psicologo);
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Cita cita = sistema.AgendarCita(paciente);
            string linkResultado = cita.DireccionConsulta;
            string linkParteNoEsperada = "https://bettercalm.com.uy/";
            bool esLinkVirtual = linkResultado.Contains(linkParteNoEsperada);
            Assert.IsFalse(esLinkVirtual);
        }

    }
}
