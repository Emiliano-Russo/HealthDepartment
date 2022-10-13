using Entidades;
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
        public void ValidarGaleria_GaleriaCancionesNull_Excepcion()
        {
            GaleriaMusical galeria = new GaleriaMusical();
            galeria.CategoriaMusical = CategoriaMusical.Cuerpo;
            galeria.Canciones = null;
            validaciones.ValidarGaleria(galeria);
        }
    }
}
