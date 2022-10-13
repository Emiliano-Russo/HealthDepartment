using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void GetTodosLosPsicologos_TraerTodosPsicologos()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            List<Psicologo> esperado = new List<Psicologo>();
            esperado.Add(psicologo);
            repositorio.AltaPsicologo(psicologo);
            List<Psicologo> resultado = repositorio.GetTodosLosPsicologos();
            bool mismosAtributos = opPsicologia.MismaLista(esperado, resultado);
            Assert.IsTrue(mismosAtributos);
        }
    }
}
