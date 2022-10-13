using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void GetPsicologo_IdExistente_SinExepciones()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            Psicologo resultado = repositorio.GetPsicologo(id);
            bool iguales = opPsicologia.MismosAtributos(psicologo, resultado);
            Assert.IsTrue(iguales);
        }

        [TestMethod]
        public void GetPsicologo_DosIdExistentes_SinConfusion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo psicologo2 = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            int id = opPsicologia.AltaPsicologo(psicologo);
            int id2 = opPsicologia.AltaPsicologo(psicologo2);
            Psicologo resultado = repositorio.GetPsicologo(id2);
            opPsicologia.MismosAtributos(psicologo2, resultado);
            Assert.IsTrue(id != id2);
        }
    }
}
