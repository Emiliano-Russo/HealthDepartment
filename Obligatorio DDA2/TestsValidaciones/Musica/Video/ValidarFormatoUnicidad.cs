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
        public void ValidarUnicidadVideo_VideoExistente_Excepcion()
        {
            Video video1 = DatosGlobalesMusica.CrearVideoCatCuerpo();
            Video video2 = DatosGlobalesMusica.CrearVideoCatCuerpo();
            repositorio.AltaVideo(video1);
            validaciones.ValidarFormatoUnicidad(video2);
        }
    }
}
