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
        public void ExisteIDsPlayList_IdsInExsitente_Excepcion()
        {
            List<int> listaIDsPlayLists = new List<int>();
            listaIDsPlayLists.Add(1);
            listaIDsPlayLists.Add(2);
            listaIDsPlayLists.Add(3);
            validaciones.ExisteIDsPlayList(listaIDsPlayLists);
        }
    }
}