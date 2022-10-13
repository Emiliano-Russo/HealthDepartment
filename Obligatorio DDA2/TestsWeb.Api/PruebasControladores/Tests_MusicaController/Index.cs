using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilidades.OperacionesEntidades;
using Web.Api.Administracion;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    [TestClass]
    public partial class UnitTest_MusicaController
    {


        [TestMethod]
        public void Index_TodasLasCategorias()
        {
            List<CategoriaMusical> categoriasMusicales = Enum.GetValues(typeof(CategoriaMusical)).Cast<CategoriaMusical>().ToList();
            mock.Setup(sistema => sistema.GetCategoriasMusicales()).Returns(categoriasMusicales);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);

            JsonResult json = musicaController.Index();
            List<string> listaResultado = (List<string>)((RespuestaJson)json.Value).Mensaje;
            Assert.IsTrue(listaResultado[0] == "Dormir");
            Assert.IsTrue(listaResultado[1] == "Meditar");
            Assert.IsTrue(listaResultado[2] == "Musica");
            Assert.IsTrue(listaResultado[3] == "Cuerpo");
        }
    }
}
