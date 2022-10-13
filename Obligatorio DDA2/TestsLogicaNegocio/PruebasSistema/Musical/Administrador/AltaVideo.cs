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
        public void AltaVideo_DatosCorrectos_Existe()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.AgregarCategoria(CategoriaMusical.Cuerpo);
            Assert.IsTrue(video.Categorias.Count == 1);
            int index = sistema.AltaVideo(video);
            Video resultado = sistema.GetVideo(index);
            bool iguales = resultado.Equals(video);
            Assert.IsTrue(iguales);
        }

        [TestMethod]
        public void AltaVideo_DatosCorrectos_ExisteEnGaleria()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            int index = sistema.AltaVideo(video);
            GaleriaMusical galeria = sistema.GetGaleriaMusical(CategoriaMusical.Cuerpo);
            bool existe = galeria.Videos.Exists(v => v.Equals(video));
            Assert.IsTrue(existe);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_NombreNull_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.Nombre = null;
            sistema.AltaVideo(video);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_DuracionNegativa_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.DuracionMins = -1;
            sistema.AltaVideo(video);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_NombreVacio_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.Nombre = "";
            sistema.AltaVideo(video);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_LinkVideoVacio_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.LinkVideo = "";
            sistema.AltaVideo(video);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_LinkVideoNull_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.LinkVideo = null;
            sistema.AltaVideo(video);
        }
    }
}
