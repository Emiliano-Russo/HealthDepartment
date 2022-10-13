using Entidades;
using Entidades.Indices;
using LogicaNegocio.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace TestsValidaciones
{
    public partial class Validacion
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreContieneNumeros_Expecion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = "Fer1234";
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DolenciasListaVacia_Excepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(new List<CategoriaDolencia>());
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreNumerico_Expecion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = "1234";
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DolenciasRepetidas2Veces_Expecion()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            listaDolencias.Add(CategoriaDolencia.Estres);
            listaDolencias.Add(CategoriaDolencia.Estres);
            listaDolencias.Add(CategoriaDolencia.Depresion);
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DolenciasRepetidas3Veces_Expecion()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            listaDolencias.Add(CategoriaDolencia.Estres);
            listaDolencias.Add(CategoriaDolencia.Estres);
            listaDolencias.Add(CategoriaDolencia.Estres);
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_CuatroDolencias_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.AgregarDolencia(CategoriaDolencia.Relaciones);
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_SinDolenciasSuficientes_Expecion()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_CategoriaDolenciaOtros_Expecion()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            listaDolencias.Add(CategoriaDolencia.Otros);
            listaDolencias.Add(CategoriaDolencia.Estres);
            listaDolencias.Add(CategoriaDolencia.Depresion);
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreNull_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = null;
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DireccionNull_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.DireccionUrbana = null;
            validaciones.ValidarFormatoPsicologo(psicologo);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DolenciasNull_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.DolenciasQueTrata = null;
            validaciones.ValidarFormatoPsicologo(psicologo);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DireccionStringVacio_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.DireccionUrbana = "";
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreStringVacio_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = "";
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_TodosDatosIncorrectos_Exepcion()
        {
            Psicologo psicologo = new Psicologo
            {
                DireccionUrbana = "",
                Nombre = null,
                FormatoConsulta = FormatoConsulta.Virtual,
                DolenciasQueTrata = new List<TipoCategoriaDolencia>()
            };
            validaciones.ValidarFormatoPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void ModificarPsicologo_PsicologoNull_Excepcion()
        {
            validaciones.ValidarFormatoPsicologo(null);
        }
    }
}
