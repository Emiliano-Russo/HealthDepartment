using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void BajaCancion_DatosExistentes_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            repositorio.AltaCancion(cancion);
            repositorio.BajaCancion(cancion.Titulo, cancion.Autor);
            bool existe = opMusica.ExisteCancionEnSistema(cancion.Titulo, cancion.Autor);
            Assert.IsFalse(existe);
        }

        [TestMethod]
        public void BajaCancion_DatosExistentes2_SinExcepcion()
        {
            Cancion cancionDormir = DatosGlobalesMusica.CrearCancionDormir();
            Cancion cancionMeditar = DatosGlobalesMusica.CrearCancionMeditar();
            repositorio.AltaCancion(cancionDormir);
            repositorio.AltaCancion(cancionMeditar);
            repositorio.BajaCancion(cancionDormir.Titulo, cancionDormir.Autor);
            bool existeCancionDormir = opMusica.ExisteCancionEnSistema(cancionDormir.Titulo, cancionDormir.Autor);
            bool existeCancionMeditar = opMusica.ExisteCancionEnSistema(cancionMeditar.Titulo, cancionMeditar.Autor);
            Assert.IsFalse(existeCancionDormir);
            Assert.IsTrue(existeCancionMeditar);
        }
    }
}
