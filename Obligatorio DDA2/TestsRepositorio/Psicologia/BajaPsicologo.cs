using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
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
            int id = repositorio.AltaPsicologo(psicologo);
            int id2 = repositorio.AltaPsicologo(psicologo);
            opPsicologia.AssertionDeBajaPsicologo(id2);
            Psicologo psicologoDevuelto = repositorio.GetPsicologo(id);
            opPsicologia.MismosAtributos(psicologo, psicologoDevuelto);
        }

        [TestMethod]
        public void BajaPsicologo_DosBajas_BajaCorrecta()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = repositorio.AltaPsicologo(psicologo);
            int id2 = repositorio.AltaPsicologo(psicologo);
            opPsicologia.AssertionDeBajaPsicologo(id);
            opPsicologia.AssertionDeBajaPsicologo(id2);
        }
    }
}
