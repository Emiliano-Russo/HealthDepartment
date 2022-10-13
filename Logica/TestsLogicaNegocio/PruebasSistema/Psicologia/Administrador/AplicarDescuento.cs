using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;
using Web.Api.Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {

        [TestMethod]
        public void AplicarDescuento_Descuento25_DescuentoRealizado()
        {
            Psicologo psicologo = opPsicologia.GetPsicologoTrataEstresRegistrado();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            opPsicologia.RegistrarCitaPacienteVeces(paciente,5);

            Descuento descuento = new Descuento
            {
                Email = paciente.Email,
                Porcentaje = 25
            };

            sistema.AplicarDescuento(descuento);

            float porcentajeDescuento = (1-(float)descuento.Porcentaje / 100);
            float precioFinalEsperado = psicologo.PrecioHora
                                        * paciente.TiempoSolicitadoHoras
                                        * porcentajeDescuento;

            Cita cita = sistema.AgendarCita(paciente);
            float precioResultado = cita.PrecioFinal;
            Assert.AreEqual(precioFinalEsperado,precioResultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AplicarDescuento_PacienteNoDerechoADescuento_Excepcion()
        {
            opPsicologia.GetPsicologoTrataEstresRegistrado();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            opPsicologia.RegistrarCitaPacienteVeces(paciente, 4);

            Descuento descuento = new Descuento
            {
                Email = paciente.Email,
                Porcentaje = 25
            };

            sistema.AplicarDescuento(descuento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AplicarDescuento_PacienteNoDerechoADescuentosSeguidos_Excepcion()
        {
            Psicologo psicologo = opPsicologia.GetPsicologoTrataEstresRegistrado();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            opPsicologia.RegistrarCitaPacienteVeces(paciente, 5);

            Descuento descuento = new Descuento
            {
                Email = paciente.Email,
                Porcentaje = 25
            };

            sistema.AplicarDescuento(descuento);
            sistema.AplicarDescuento(descuento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AplicarDescuento_PacienteNoDerechoADescuentosSeguidosExtraCreditos_Excepcion()
        {
            Psicologo psicologo = opPsicologia.GetPsicologoTrataEstresRegistrado();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            opPsicologia.RegistrarCitaPacienteVeces(paciente, 10);

            Descuento descuento = new Descuento
            {
                Email = paciente.Email,
                Porcentaje = 25
            };

            sistema.AplicarDescuento(descuento);
            sistema.AplicarDescuento(descuento);
        }

    }
}
