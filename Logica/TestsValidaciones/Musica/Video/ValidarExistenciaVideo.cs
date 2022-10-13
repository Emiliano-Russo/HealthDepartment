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
        public void ValidarFormatoExistenciaVideo_VideoNoExistente_Excepcion()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            validaciones.ValidarFormatoExistenciaVideo(video);
            validaciones.ValidarFormatoUnicidad(video);
        }
    }
}
