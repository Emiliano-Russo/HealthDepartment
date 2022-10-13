using LogicaNegocio.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsValidaciones
{
    public partial class Validacion
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetPlayList_IdInExsitente_Excepcion()
        {
            validaciones.ValidarExistenciaPlayList(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetPlayList_IdInExsitente2_Excepcion()
        {
            validaciones.ValidarExistenciaPlayList(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void GetPlayList_IdInExsitente3_Excepcion()
        {
            validaciones.ValidarExistenciaPlayList(0);
        }
    }
}
