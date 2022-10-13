using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using System;
using System.Linq;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetProblematicas_TraerTodasLasProblematicas_TodasLasEsperadas()
        {
            List<CategoriaDolencia> lista = sistema.GetProblematicas();
            bool mismoLargo = lista.Count == Enum.GetNames(typeof(CategoriaDolencia)).Length;
            Assert.IsTrue(mismoLargo);
            Assert.IsTrue(lista.Count == lista.Distinct().Count());
        }
    }
}
