using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using System;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void BajaCancion_DatosExistentes_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            sistema.AltaCancion(cancion);
            sistema.BajaCancion(cancion.Titulo, cancion.Autor);
            bool existe = opMusica.ExisteCancionEnSistema(cancion.Titulo, cancion.Autor);
            Assert.IsFalse(existe);
        }

        [TestMethod]
        public void BajaCancion_DatosExistentes2_SinExcepcion()
        {
            Cancion cancionDormir = DatosGlobalesMusica.CrearCancionDormir();
            Cancion cancionMeditar = DatosGlobalesMusica.CrearCancionMeditar();
            sistema.AltaCancion(cancionDormir);
            sistema.AltaCancion(cancionMeditar);
            sistema.BajaCancion(cancionDormir.Titulo, cancionDormir.Autor);
            bool existeCancionDormir = opMusica.ExisteCancionEnSistema(cancionDormir.Titulo, cancionDormir.Autor);
            bool existeCancionMeditar = opMusica.ExisteCancionEnSistema(cancionMeditar.Titulo, cancionMeditar.Autor);
            Assert.IsFalse(existeCancionDormir);
            Assert.IsTrue(existeCancionMeditar);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void BajaCancion_AutorVacio_SinExcepcion()
        {
            Cancion cancionDormir = DatosGlobalesMusica.CrearCancionDormir();
            cancionDormir.Autor = "";
            sistema.BajaCancion(cancionDormir.Titulo, cancionDormir.Autor);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void BajaCancion_AutorNulo_SinExcepcion()
        {
            Cancion cancionDormir = DatosGlobalesMusica.CrearCancionDormir();
            cancionDormir.Autor = null;
            sistema.BajaCancion(cancionDormir.Titulo, cancionDormir.Autor);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void BajaCancion_TituloVacio_SinExcepcion()
        {
            Cancion cancionDormir = DatosGlobalesMusica.CrearCancionDormir();
            cancionDormir.Titulo = "";
            sistema.BajaCancion(cancionDormir.Titulo, cancionDormir.Autor);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void BajaCancion_TituloNulo_SinExcepcion()
        {
            Cancion cancionDormir = DatosGlobalesMusica.CrearCancionDormir();
            cancionDormir.Titulo = null;
            sistema.BajaCancion(cancionDormir.Titulo, cancionDormir.Autor);
        }
    }
}
