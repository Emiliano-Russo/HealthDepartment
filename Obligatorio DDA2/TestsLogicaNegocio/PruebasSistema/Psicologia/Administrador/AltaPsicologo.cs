using Entidades;
using Entidades.Indices;
using Interfaces;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Utilidades;
using Utilidades.OperacionesEntidades;

namespace TestsLogicaNegocio
{
    [TestClass]
    public partial class SistemaTest
    {
         ISistema sistema;
         OperacionesPsicologia opPsicologia;
         OperacionesMusica opMusica;
         DatosGlobalesMusica datosGlobalesMusica;
         

        [TestInitialize]
        public void Inicializar()
        {
            sistema = new Sistema();
            sistema.SetMemoria(TipoMemoria.RAM);
            opPsicologia = new OperacionesPsicologia(sistema);
            opMusica = new OperacionesMusica(sistema);
            datosGlobalesMusica = new DatosGlobalesMusica(sistema);
        }

        [TestCleanup]
        public void Limpiar()
        {
           sistema.BorrarDatosDePrueba();
        }

        [TestMethod]
        public void AltaPsicologo_DatosCorrectos_SinExpeciones()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            opPsicologia.AssertionDeAltaPsicologo(psicologo);
        }

        [TestMethod]
        public void AltaPsicologo_DatosCorrectos2_SinExpeciones()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            listaDolencias.Add(CategoriaDolencia.Enojo);
            listaDolencias.Add(CategoriaDolencia.Estres);
            listaDolencias.Add(CategoriaDolencia.Relaciones);

            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            opPsicologia.AssertionDeAltaPsicologo(psicologo);
        }

        [TestMethod]
        public void AltaPsicologo_DatosCorrectos3_SinExpeciones()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            listaDolencias.Add(CategoriaDolencia.Enojo);
            listaDolencias.Add(CategoriaDolencia.Estres);

            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            opPsicologia.AssertionDeAltaPsicologo(psicologo);
        }

        [TestMethod]
        public void AltaPsicologo_DatosCorrectos4_SinExpeciones()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            listaDolencias.Add(CategoriaDolencia.Enojo);
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            opPsicologia.AssertionDeAltaPsicologo(psicologo);
        }

        [TestMethod]
        public void AltaPsicologo_DobleRegistroMismosDatos_SinExpeciones()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id1 = opPsicologia.AssertionDeAltaPsicologo(psicologo);
            int id2 = opPsicologia.AssertionDeAltaPsicologo(psicologo);
            Assert.IsTrue(id1 != id2);
        }

        [TestMethod]
        public void AltaPsicologo_TripleRegistroMismosDatos_SinExpeciones()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            int id1 = opPsicologia.AssertionDeAltaPsicologo(psicologo);
            int id2 = opPsicologia.AssertionDeAltaPsicologo(psicologo);
            int id3 = opPsicologia.AssertionDeAltaPsicologo(psicologo);
            Assert.IsTrue(id1 != id2 && id2 != id3 && id1 != id3);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreContieneNumeros_Expecion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = "Fer1234";
            sistema.AltaPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreNumerico_Expecion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = "1234";
            sistema.AltaPsicologo(psicologo);
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
            sistema.AltaPsicologo(psicologo);
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
            sistema.AltaPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_CuatroDolencias_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.AgregarDolencia(CategoriaDolencia.Relaciones);
            sistema.AltaPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_SinDolenciasSuficientes_Expecion()
        {
            List<CategoriaDolencia> listaDolencias = new List<CategoriaDolencia>();
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.SustituirListaDolencias(listaDolencias);
            sistema.AltaPsicologo(psicologo);
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
            sistema.AltaPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreNull_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = null;
            sistema.AltaPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DireccionNull_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.DireccionUrbana = null;
            sistema.AltaPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DolenciasNull_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.DolenciasQueTrata = null;
            sistema.AltaPsicologo(psicologo);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_DireccionStringVacio_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.DireccionUrbana = "";
            sistema.AltaPsicologo(psicologo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPsicologia))]
        public void AltaPsicologo_NombreStringVacio_Exepcion()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoEstandar();
            psicologo.Nombre = "";
            sistema.AltaPsicologo(psicologo);
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
            sistema.AltaPsicologo(psicologo);
        }
    }
}
