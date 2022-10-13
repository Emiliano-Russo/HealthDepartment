using Entidades.Entidades;
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
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_NombreNull_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.Nombre = null;
            validaciones.ValidarFormatoExistenciaVideo(video);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_DuracionNegativa_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.DuracionMins = -1;
            validaciones.ValidarFormatoExistenciaVideo(video);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_NombreVacio_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.Nombre = "";
            validaciones.ValidarFormatoExistenciaVideo(video);

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_LinkVideoVacio_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.LinkVideo = "";
            validaciones.ValidarFormatoExistenciaVideo(video);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaVideo_LinkVideoNull_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            video.LinkVideo = null;
            validaciones.ValidarFormatoExistenciaVideo(video);
        }
    }
}
