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
       public void BajaVideo_IdExistente_SeRemueve()
        {
            Video video = DatosGlobalesMusica.CrearVideoCatCuerpo();
            int index = sistema.AltaVideo(video);
            sistema.BajaVideo(index);
            bool existe = opMusica.ExisteVideoEnSistema(index);
            Assert.IsFalse(existe);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void BajaVideo_IdNoExistente_Excepcion()
        {
            sistema.BajaVideo(777);
        }
    }
}
