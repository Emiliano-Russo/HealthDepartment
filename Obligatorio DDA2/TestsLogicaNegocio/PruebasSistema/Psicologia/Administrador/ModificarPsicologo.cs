using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using System;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;
using Entidades.Indices;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {

        [TestMethod]
        public void ModificarPsicologo_SinModificacion_NoSeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            sistema.ModificarPsicologo(id, psicologo);
            Psicologo resultado = sistema.GetPsicologo(id);
            Assert.IsTrue(psicologo.Nombre == resultado.Nombre);
            Assert.IsTrue(psicologo.FormatoConsulta == resultado.FormatoConsulta);
            Assert.IsTrue(opPsicologia.SonSecuencialmenteIguales(psicologo.DolenciasQueTrata, resultado.DolenciasQueTrata));
            Assert.IsTrue(psicologo.DireccionUrbana == resultado.DireccionUrbana);
        }

        [TestMethod]
        public void ModificarPsicologo_NombreDiferente_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id =  opPsicologia.AltaPsicologo(psicologo);
            psicologo.Nombre = psicologo.Nombre + "s";
            sistema.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = sistema.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.Nombre == resultado.Nombre);
        }


        [TestMethod]
        public void ModificarPsicologo_DireccionUrbanaDiferente_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.DireccionUrbana = psicologo.DireccionUrbana + "s";
            sistema.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = sistema.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.DireccionUrbana == resultado.DireccionUrbana);
        }


        [TestMethod]
        public void ModificarPsicologo_FormatoConsultaDiferente_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.FormatoConsulta = FormatoConsulta.Virtual;
            sistema.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = sistema.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.FormatoConsulta == resultado.FormatoConsulta);
        }

        [TestMethod]
        public void ModificarPsicologo_DolenciasDiferentes_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            List<TipoCategoriaDolencia> listaTipo = (List<TipoCategoriaDolencia>) psicologo.DolenciasQueTrata;
            List<CategoriaDolencia> lista = opPsicologia.Transformar(listaTipo);
            lista.RemoveAt(0);
            psicologo.SustituirListaDolencias(lista);
            sistema.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = sistema.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.DolenciasQueTrata == resultado.DolenciasQueTrata);
        }

        [TestMethod]
        public void ModificarPsicologo_PrecioDiferente_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            float precioHoraOriginal = psicologo.PrecioHora;
            int id = sistema.AltaPsicologo(psicologo);
            psicologo.PrecioHora = psicologo.PrecioHora + 100;
            sistema.ModificarPsicologo(id, psicologo);
            Psicologo resultado = sistema.GetPsicologo(0);
            Assert.AreNotSame(precioHoraOriginal, resultado.PrecioHora);
            Assert.AreEqual(resultado.PrecioHora,(psicologo.PrecioHora));
        }

        [TestMethod]
        public void ModificarPsicologo_UnaModificacion_SinConfusion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            int id2 = opPsicologia.AltaPsicologo(psicologo);

            psicologo.Nombre = psicologo.Nombre + "s";
            sistema.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = sistema.GetPsicologo(id);
            Assert.IsTrue(psicologoAcomparar.Nombre != resultado.Nombre);

            resultado = sistema.GetPsicologo(id2);
            Assert.IsTrue(psicologo.Nombre != resultado.Nombre);
        }

        [TestMethod]
        public void ModificarPsicologo_DobleModificacion_Diferentes()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            int id2 = opPsicologia.AltaPsicologo(psicologo);

            psicologo.Nombre = psicologo.Nombre + "s";          
            sistema.ModificarPsicologo(id, psicologo);
            psicologo.Nombre = psicologo.Nombre + "n";
            sistema.ModificarPsicologo(id2, psicologo);

            Psicologo resultado = sistema.GetPsicologo(id);
            Psicologo resultado2 = sistema.GetPsicologo(id2);
            Assert.IsFalse(resultado.Nombre == resultado2.Nombre);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_NombreVacio_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.Nombre = "";
            sistema.ModificarPsicologo(id, psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_DireccionUrbanaVacia_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.DireccionUrbana = "";
            sistema.ModificarPsicologo(id, psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_DolenciasListaVacia_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.SustituirListaDolencias(new List<CategoriaDolencia>());
            sistema.ModificarPsicologo(id, psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_NombreNull_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.Nombre = null;
            sistema.ModificarPsicologo(id, psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_DireccionUrbanaNull_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.DireccionUrbana = null;
            sistema.ModificarPsicologo(id, psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_DolenciasNull_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.DolenciasQueTrata = null;
            sistema.ModificarPsicologo(id, psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_PsicologoNull_Excepcion()
        {
            sistema.ModificarPsicologo(1, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_ModIdNoExistente_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            sistema.ModificarPsicologo(999, psicologo);
        }
    }
}
