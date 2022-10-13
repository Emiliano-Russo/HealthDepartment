using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Administracion;
using Web.Api.Entidades.Presentacion;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {
        [TestMethod]
        public void GetGaleriaMusical_Meditar_Iguales()
        {
            GaleriaMusical galeria = new GaleriaMusical();
            galeria.CategoriaMusical = CategoriaMusical.Meditar;
            mock.Setup(sistema => sistema.GetGaleriaMusical(CategoriaMusical.Meditar)).
                Returns(galeria);

            MusicaController musicaCotroller = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaCotroller);
            JsonResult resultado = musicaCotroller.GetGaleriaMusical(CategoriaMusical.Meditar);
            GaleriaMusicalExhibicion galeriaResultado = (GaleriaMusicalExhibicion)((RespuestaJson)resultado.Value).Mensaje;
            Assert.IsTrue(galeriaResultado.CategoriaMusical == "Meditar");
        }

        [TestMethod]
        public void GetGaleriaMusical_Dormir_Iguales()
        {
            GaleriaMusical galeria = new GaleriaMusical();
            mock.Setup(sistema => sistema.GetGaleriaMusical(CategoriaMusical.Dormir))
                .Returns(galeria);

            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult resultado = musicaController.GetGaleriaMusical(CategoriaMusical.Dormir);
            GaleriaMusicalExhibicion galeriaRestulado = (GaleriaMusicalExhibicion)((RespuestaJson)resultado.Value).Mensaje;
            Assert.IsTrue(galeriaRestulado.CategoriaMusical == "Dormir");
        }

        [TestMethod]
        public void GetGaleriaMusical_Musica_Iguales()
        {
            GaleriaMusical galeria = new GaleriaMusical();
            galeria.CategoriaMusical = CategoriaMusical.Musica;
            mock.Setup(sistema => sistema.GetGaleriaMusical(CategoriaMusical.Musica))
                .Returns(galeria);

            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult resultado = musicaController.GetGaleriaMusical(CategoriaMusical.Musica);
            GaleriaMusicalExhibicion galeriaRestulado = (GaleriaMusicalExhibicion)((RespuestaJson)resultado.Value).Mensaje;
            Assert.IsTrue(galeriaRestulado.CategoriaMusical == "Musica");
        }

        [TestMethod]
        public void GetGaleriaMusical_Cuerpo_Iguales()
        {
            GaleriaMusical galeria = new GaleriaMusical();
            galeria.CategoriaMusical = CategoriaMusical.Cuerpo;
            mock.Setup(sistema => sistema.GetGaleriaMusical(CategoriaMusical.Cuerpo))
                .Returns(galeria);

            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult resultado = musicaController.GetGaleriaMusical(CategoriaMusical.Cuerpo);
            GaleriaMusicalExhibicion galeriaRestulado = (GaleriaMusicalExhibicion)((RespuestaJson)resultado.Value).Mensaje;
            Assert.IsTrue(galeriaRestulado.Canciones == null
                && galeriaRestulado.Canciones == null
                && galeriaRestulado.CategoriaMusical == "Cuerpo");
        }
    }
}
