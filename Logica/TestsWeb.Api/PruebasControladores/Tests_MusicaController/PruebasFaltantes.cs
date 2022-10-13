using Entidades;
using Entidades.Entidades;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
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
using Web.Api.Entidades;

namespace TestsWeb.Api.PruebasControladores.Tests_MusicaController
{
    public partial class UnitTest_MusicaController
    {

        /*
          int idVideo = 1;
            Video video = new Video();
            video.ID = idVideo;

            mock.Setup(sistema => sistema.AltaVideo(video)).Returns(idVideo);
            MusicaController musicaController = new MusicaController(mock.Object);
            configurador.ConfigurarHttpResponse(musicaController);
            JsonResult json = musicaController.RegistrarVideo(video, token);
            int resultado = (int)(((RespuestaJson)json.Value).Mensaje);
            Assert.AreEqual(idVideo, resultado);
         
         */




        [TestMethod]
        public void GetTodasLasImportaciones_ListaNoVacia()
        {
            mock.Setup(sistema => sistema.GetNombresImportadores()).Returns(new List<string>());
            MusicaController musicaController = new MusicaController(mock.Object);
            JsonResult json = musicaController.GetTodasLasImportaciones();
            List<string> lista = (List<string>)json.Value;
            Assert.IsTrue(lista != null);
        }

        [TestMethod]
        public void RegistrarVideoConPlayLists_Ok()
        {
            Video video = new Video();
            List<int> playlists = new List<int>();
            int id = 1;
            mock.Setup(sistema => sistema.AltaVideo(video, playlists)).Returns(id);
            MusicaController musicaController = new MusicaController(mock.Object);
            VideoPlayList ent = new VideoPlayList
            {
                Video = video,
                IdPlayLists = playlists
            };
            JsonResult json = musicaController.RegistrarVideoConPlayLists(ent, token);
            RespuestaJson respuesta = (RespuestaJson)json.Value;
            string mensajeRetorno = (string)respuesta.Mensaje;
            string esperado = "Video Registrado!";
            Assert.AreEqual(esperado, mensajeRetorno);
        }
        
    }
}
