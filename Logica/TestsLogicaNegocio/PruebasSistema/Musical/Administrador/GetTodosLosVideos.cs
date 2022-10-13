using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;
using Web.Api.Entidades;
using Entidades.Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetTodosLosVideos_VideosRegistrados_UnItem()
        {
            Video videoCatCuerpo = DatosGlobalesMusica.CrearVideoCatCuerpo();
            sistema.AltaVideo(videoCatCuerpo);
            List<Video> todosLosVideos = sistema.GetTodosLosVideos();
            Assert.IsTrue(todosLosVideos.Exists(x => x.LinkVideo == videoCatCuerpo.LinkVideo));
        }

        [TestMethod]
        public void GetTodosLosVideos_SinVideos_ListaVacia()
        {
            List<Video> videos = sistema.GetTodosLosVideos();
            Assert.IsTrue(videos.Count == 0);
        }
    }
}
