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
        public void BajaPsicologo_IdExistente_BajaCorrecta()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            opPsicologia.AssertionDeBajaPsicologo(id);
        }

        [TestMethod]
        public void BajaPsicologo_IdExistente_BajaCorrectaCorrespondiente()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = sistema.AltaPsicologo(psicologo);
            int id2 = sistema.AltaPsicologo(psicologo);
            opPsicologia.AssertionDeBajaPsicologo(id2);
            Psicologo psicologoDevuelto =  sistema.GetPsicologo(id);
            opPsicologia.MismosAtributos(psicologo, psicologoDevuelto);
        }

        [TestMethod]
        public void BajaPsicologo_DosBajas_BajaCorrecta()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = sistema.AltaPsicologo(psicologo);
            int id2 = sistema.AltaPsicologo(psicologo);
            opPsicologia.AssertionDeBajaPsicologo(id);
            opPsicologia.AssertionDeBajaPsicologo(id2);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void BajaPsicologo_BajaIdNoExistente_Excepcion()
        {
            sistema.BajaPsicologo(1);
        }
      
    }
}
