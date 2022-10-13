using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void TraerMailsAptosParaDescuento_SinCitas_ListaVacia()
        {
            List<string> mails = sistema.TraerMailsAptosParaDescuento();
            Assert.IsTrue(mails.Count == 0);
        }

        [TestMethod]
        public void TraerMailsAptosParaDescuento_UnMailApto_UnicoMailEnLista()
        {
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            sistema.AltaPsicologo(psicologo);
            opPsicologia.RegistrarCitaPacienteVeces(paciente, 5);
            List<string> lista = sistema.TraerMailsAptosParaDescuento();
            bool contieneMail = lista.Contains(paciente.Email);
            Assert.IsTrue(contieneMail);
        }


        [TestMethod]
        public void TraerMailsAptosParaDescuento_DosMailsAptos_DosMailsEnLista()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            sistema.AltaPsicologo(psicologo);
            Paciente pacienteA = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            Paciente pacienteB = pacienteA.Clon();
            Paciente pacienteC = pacienteA.Clon();
            pacienteC.Email = pacienteA.Email + "h";
            pacienteB.Email = pacienteA.Email + "s";
            opPsicologia.RegistrarCitaPacienteVeces(pacienteA, 5);
            opPsicologia.RegistrarCitaPacienteVeces(pacienteB, 5);
            opPsicologia.RegistrarCitaPacienteVeces(pacienteC, 4);

            List<string> listaMails = sistema.TraerMailsAptosParaDescuento();
            Assert.IsTrue(listaMails.Count == 2);
            Assert.IsTrue(listaMails.Contains(pacienteA.Email));
            Assert.IsTrue(listaMails.Contains(pacienteB.Email));
            Assert.IsFalse(listaMails.Contains(pacienteC.Email));
        }


    }
}
