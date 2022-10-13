using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
       
        [TestMethod]
        public void GetProblematicas_Todas()
        {
            List<CategoriaDolencia> lista = this.repositorio.GetProblematicas();
            int largo = CategoriaDolencia.GetNames(typeof(CategoriaDolencia)).Length;
            Assert.IsTrue(lista.Count == largo);
        }
    }
}
