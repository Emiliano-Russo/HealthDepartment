using Entidades;
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
        public void AltaCancion_AutorVacio_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Autor = "";
            validaciones.ValidarFormatoExistenciaCancion(cancion.Autor, cancion.Titulo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_AutorNulo_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Autor = null;
            validaciones.ValidarFormatoExistenciaCancion(cancion.Autor, cancion.Titulo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_TituloVacio_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Titulo = "";
            validaciones.ValidarFormatoExistenciaCancion(cancion.Autor, cancion.Titulo);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_TituloNulo_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Titulo = null;
            validaciones.ValidarFormatoExistenciaCancion(cancion.Autor, cancion.Titulo);
        }
    }
}
