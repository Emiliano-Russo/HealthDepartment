using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
       
        [TestMethod]
        public void AgendarCita_Paciente_CorrespondanLosDatos()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologo = opPsicologia.GetPsicologoTrataEstresRegistrado();
            Cita cita = repositorio.AgendarCita(paciente);
            Assert.AreEqual(psicologo.Nombre, cita.NombrePsicologo);
        }

        [TestMethod]
        public void AgendarCita_PacienteEstres_PrimerPsicologoRegistrado()
        {
            Paciente pacienteEstresado = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();

            int Id1 = opPsicologia.AltaPsicologo(psicologoTrataEstres);
            int Id2 = opPsicologia.AltaPsicologo(psicologoTrataEstres);

            Cita cita = repositorio.AgendarCita(pacienteEstresado);
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

            Cita cita = repositorio.AgendarCita(pacienteEstresado);
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
            Cita cita = repositorio.AgendarCita(pacienteEstresado);
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
            Cita cita = repositorio.AgendarCita(pacienteEstresado);
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
            Cita cita = repositorio.AgendarCita(pacienteEstresado);
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
            Cita cita = repositorio.AgendarCita(pacienteEstresado);
            bool mismaSemana = Util.FechasEnMismaSemanaEmpezandoElSabado(DateTime.Now, cita.FechaConsulta);

            Assert.IsFalse(Util.EsSabadoODomingo(cita.FechaConsulta));
            Assert.IsFalse(mismaSemana);
            Assert.AreEqual(cita.IdPsicologo, Id2);
            Assert.AreNotEqual(Id1, Id2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AgendarCita_PacienteNull_Excepcion()
        {

            opPsicologia.RegistrarPsicologoEstresEn();
            repositorio.AgendarCita(null);
        }


        [TestMethod]
        public void AgendarCita_Paciente_LinkUrbano()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            psicologo.FormatoConsulta = FormatoConsulta.Presencial;
            repositorio.AltaPsicologo(psicologo);
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Cita cita = repositorio.AgendarCita(paciente);
            string linkResultado = cita.DireccionConsulta;
            string linkParteNoEsperada = "https://bettercalm.com.uy/";
            bool esLinkVirtual = linkResultado.Contains(linkParteNoEsperada);
            Assert.IsFalse(esLinkVirtual);
        }
    }
}
