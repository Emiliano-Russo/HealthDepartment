using Entidades;
using LogicaNegocio.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;
using Web.Api.Entidades;

namespace TestsValidaciones
{
    public partial class Validacion
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AplicarDescuento_PacienteNoDerechoADescuento_Excepcion()
        {
            Psicologo psicologo = opPsicologia.GetPsicologoTrataEstresRegistrado();
            Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
            opPsicologia.RegistrarCitaPacienteVeces(paciente, 4);

            Descuento descuento = new Descuento
            {
                Email = paciente.Email,
                Porcentaje = 25
            };

            validaciones.ValidacionDescuento(descuento);
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
            repositorio.GuardarDescuento(descuento);
            validaciones.ValidacionDescuento(descuento);
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

            repositorio.GuardarDescuento(descuento);
            validaciones.ValidacionDescuento(descuento);
        }
    }
}
