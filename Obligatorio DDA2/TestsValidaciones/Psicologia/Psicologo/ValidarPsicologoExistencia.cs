using LogicaNegocio.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsValidaciones
{
    public partial class Validacion
    {

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ValidarPsicologoExistencia_IdNoExistente2_Excepcion()
        {
            validaciones.ValidarPsicologoExistencia(55);
        }
    }
}
