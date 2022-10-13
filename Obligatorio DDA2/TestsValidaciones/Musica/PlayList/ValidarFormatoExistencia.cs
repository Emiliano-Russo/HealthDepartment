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
        public void AltaCancion_ListaVacio_Excepcion()
        {
            List<int> listaPlaylist = new List<int>();
            validaciones.ValidarFormatoExistencia(listaPlaylist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_ListaNula_Excepcion()
        {
            List<int> listaPlaylist = null;
            validaciones.ValidarFormatoExistencia(listaPlaylist);
        }
    }
}
