using Entidades;
using Entidades.Indices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {

        [TestMethod]
        public void ModificarPsicologo_SinModificacion_NoSeDiferencian()
        {

            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            repositorio.ModificarPsicologo(id, psicologo);
            Psicologo resultado = repositorio.GetPsicologo(id);
            Assert.IsTrue(psicologo.Nombre == resultado.Nombre);
            Assert.IsTrue(psicologo.FormatoConsulta == resultado.FormatoConsulta);
            Assert.IsTrue(opPsicologia.SonIguales(psicologo.DolenciasQueTrata, resultado.DolenciasQueTrata));
            Assert.IsTrue(psicologo.DireccionUrbana == resultado.DireccionUrbana);
            
        }

        [TestMethod]
        public void ModificarPsicologo_NombreDiferente_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.Nombre = psicologo.Nombre + "s";
            repositorio.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = repositorio.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.Nombre == resultado.Nombre);
        }


        [TestMethod]
        public void ModificarPsicologo_DireccionUrbanaDiferente_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.DireccionUrbana = psicologo.DireccionUrbana + "s";
            repositorio.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = repositorio.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.DireccionUrbana == resultado.DireccionUrbana);
        }


        [TestMethod]
        public void ModificarPsicologo_FormatoConsultaDiferente_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            psicologo.FormatoConsulta = FormatoConsulta.Virtual;
            repositorio.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = repositorio.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.FormatoConsulta == resultado.FormatoConsulta);
        }

        [TestMethod]
        public void ModificarPsicologo_DolenciasDiferentes_SeDiferencian()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            List<TipoCategoriaDolencia> listaTipo = (List<TipoCategoriaDolencia>)psicologo.DolenciasQueTrata;
            List<CategoriaDolencia> lista = opPsicologia.Transformar(listaTipo);
            lista.RemoveAt(0);
            psicologo.SustituirListaDolencias(lista);
            repositorio.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = repositorio.GetPsicologo(id);
            Assert.IsFalse(psicologoAcomparar.DolenciasQueTrata == resultado.DolenciasQueTrata);
        }

        [TestMethod]
        public void ModificarPsicologo_UnaModificacion_SinConfusion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            int id2 = opPsicologia.AltaPsicologo(psicologo);

            psicologo.Nombre = psicologo.Nombre + "s";
            repositorio.ModificarPsicologo(id, psicologo);
            Psicologo psicologoAcomparar = DatosGlobalesPsicologia.GetPsicologoEstandar();
            Psicologo resultado = repositorio.GetPsicologo(id);
            Assert.IsTrue(psicologoAcomparar.Nombre != resultado.Nombre);

            resultado = repositorio.GetPsicologo(id2);
            Assert.IsTrue(psicologo.Nombre != resultado.Nombre);
        }

        [TestMethod]
        public void ModificarPsicologo_DobleModificacion_Diferentes()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id = opPsicologia.AltaPsicologo(psicologo);
            int id2 = opPsicologia.AltaPsicologo(psicologo);

            psicologo.Nombre = psicologo.Nombre + "s";
            repositorio.ModificarPsicologo(id, psicologo);
            psicologo.Nombre = psicologo.Nombre + "n";
            repositorio.ModificarPsicologo(id2, psicologo);

            Psicologo resultado = repositorio.GetPsicologo(id);
            Psicologo resultado2 = repositorio.GetPsicologo(id2);
            Assert.IsFalse(resultado.Nombre == resultado2.Nombre);
        }

    }
}
