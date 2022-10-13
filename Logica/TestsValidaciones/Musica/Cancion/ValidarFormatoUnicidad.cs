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
        public void AltaCancion_DescripcionVaciaInvalido_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Descripcion = "";
            validaciones.ValidarFormatoUnicidad(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_DuracionNegativa_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Duracion = -500;
            validaciones.ValidarFormatoUnicidad(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_LinkAudioVacio_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.LinkAudio = "";
            validaciones.ValidarFormatoUnicidad(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_DescripcionNula_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Descripcion = null;
            validaciones.ValidarFormatoUnicidad(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_LinkAudioNulo_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.LinkAudio = null;
            validaciones.ValidarFormatoUnicidad(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_Descripcion200Caracteres_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Descripcion = "aaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            validaciones.ValidarFormatoUnicidad(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_CancionExistente_Excepcion()
        {
            Cancion cancion1 = DatosGlobalesMusica.CrearCancionDormir();
            Cancion cancion2 = DatosGlobalesMusica.CrearCancionDormir();
            repositorio.AltaCancion(cancion1);
            validaciones.ValidarFormatoUnicidad(cancion2);
        }
    }
}
