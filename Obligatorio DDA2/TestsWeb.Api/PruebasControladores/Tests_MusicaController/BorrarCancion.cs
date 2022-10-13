using Entidades;
using Interfaces;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;
using Utilidades.OperacionesEntidades;
using Web.Api.Entidades;
using Web.Api.Administracion;
using Repositorio.Repositorio.RepositorioBDD;
using Microsoft.EntityFrameworkCore;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {
        Mock<ISistema> mock;
        Cancion cancionEstandar;
        private RepositorioBDD repositorio;
        OperacionesMusica opMusica;
        DatosGlobalesMusica datosGlobalesMusica;
        string token;
        Playlist playlistEstandar;
        ConfiguracionHTTP configurador;

        [TestInitialize]
        public void Inicializar()
        {

            mock = new Mock<ISistema>();
            configurador = new ConfiguracionHTTP();
            cancionEstandar = DatosGlobalesMusica.CancionDatosCorrectos();
            this.token = "AX8";
            mock.Setup(sistema => sistema.ExisteSesionAdmin(token))
                .Returns(true);
            mock.Setup(sistema => sistema.ExisteSesionSuperAdmin(token))
                .Returns(true);          
            playlistEstandar = new Playlist();
            var opciones = new DbContextOptionsBuilder<EntidadesContexto>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;
            this.repositorio = new RepositorioBDD(opciones);
            opMusica = new OperacionesMusica(this.repositorio);
        }



        [TestMethod]
        public void BorrarCancion_CancionExistente_CancionBorrada()
        {
            mock.Setup(sistema => sistema.BajaCancion(cancionEstandar.Titulo, cancionEstandar.Autor));
            MusicaController musicaController = new MusicaController(mock.Object);           
            CancionIdentificar cancion = new CancionIdentificar();
            cancion.Autor = cancionEstandar.Autor;
            cancion.Titulo = cancionEstandar.Titulo;
            JsonResult resultado = musicaController.BorrarCancion(cancion, this.token);
            RespuestaJson resul = (RespuestaJson)resultado.Value;
            string esperado = "Cancion borrada";
            Assert.AreEqual(esperado, resul.Mensaje);
        }

       

        [TestMethod]
        public void BorrarCancion_CancionInexistente_NoExisteCancion()
        {
            Exception excepcionMusica = new ExcepcionMusica("No existe la cancion");
            mock.Setup(sistema => sistema.BajaCancion(cancionEstandar.Titulo, cancionEstandar.Autor)).
                Throws(excepcionMusica);
            MusicaController musicaController = new MusicaController(mock.Object);

            configurador.ConfigurarHttpResponse(musicaController);

            CancionIdentificar cancion = new CancionIdentificar();
            cancion.Autor = cancionEstandar.Autor;
            cancion.Titulo = cancionEstandar.Titulo;
            JsonResult resultado = musicaController.BorrarCancion(cancion, this.token);
            RespuestaJson resul = (RespuestaJson)resultado.Value;
            string esperado = excepcionMusica.Message;
            Assert.AreEqual(esperado, resul.Mensaje);
        }
    }
}
