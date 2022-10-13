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
        public void GetPsicologo_IdExistente_SinExepciones()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            Psicologo resultado = sistema.GetPsicologo(id);
            opPsicologia.MismosAtributos(psicologo, resultado);
        }

        [TestMethod]
        public void GetPsicologo_DosIdExistentes_SinConfusion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo psicologo2 = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            int id = opPsicologia.AltaPsicologo(psicologo);
            int id2 = opPsicologia.AltaPsicologo(psicologo2);
            Psicologo resultado = sistema.GetPsicologo(id2);
            opPsicologia.MismosAtributos(psicologo2, resultado);
            Assert.IsTrue(id != id2);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void GetPsicologo_IdNoExistente_Excepcion()
        {
            Psicologo resultado = sistema.GetPsicologo(55);
        }
    }
}
