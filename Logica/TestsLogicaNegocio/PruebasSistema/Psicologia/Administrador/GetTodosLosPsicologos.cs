using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using System.Collections.Generic;
using Utilidades;
using System;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetTodosLosPsicologos_TraerTodosPsicologos()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            List<Psicologo> esperado = new List<Psicologo>();
            esperado.Add(psicologo);
            sistema.AltaPsicologo(psicologo);
            List<Psicologo> resultado = sistema.GetTodosLosPsicologos();
            bool mismosAtributos = opPsicologia.MismaLista(esperado, resultado);
            Assert.IsTrue(mismosAtributos);
        }

       
    }
}
