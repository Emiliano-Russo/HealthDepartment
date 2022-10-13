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
        public void AltaPsicologo_Psicologo_SeGuarda()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = repositorio.AltaPsicologo(psicologo);
            Psicologo resultado = repositorio.GetPsicologo(id);
            bool iguales = opPsicologia.MismosAtributos(resultado, psicologo);
            Assert.IsTrue(iguales);
        }

        [TestMethod]
        public void AltaPsicogolo_SinNombre_SeGuarda()
        {          
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = "";
            int id = repositorio.AltaPsicologo(psicologo);
            Psicologo resultado = repositorio.GetPsicologo(id);
            bool iguales = opPsicologia.MismosAtributos(resultado, psicologo);
            Assert.IsTrue(iguales);         
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AltaPsicologo_null_Excepcion()
        {
            repositorio.AltaPsicologo(null);
        }
    }
}
