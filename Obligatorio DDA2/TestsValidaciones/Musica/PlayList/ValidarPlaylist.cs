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
        public void RegistrarPlaylist_DescripcionVacia_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Descripcion = "";
            validaciones.ValidarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_NombreVacio_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Nombre = "";
            validaciones.ValidarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_DescripcionNula_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Descripcion = null;
            validaciones.ValidarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_NombreNulo_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Nombre = null;
            validaciones.ValidarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_ListaCancionesNula_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.SustituirListaCancion(null);
            validaciones.ValidarPlaylist(playlist);
        }
    }
}
