using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;
using Entidades.Indices;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void AltaCancion_CancionDormir_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        public void AltaCancion_DatosValidos_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            List<int> listaPlaylist = datosGlobalesMusica.GetPlayListIDRegistradasEn();
            sistema.AltaCancion(cancion, listaPlaylist);
        }

        [TestMethod]
        public void AltaCancion_CancionMeditar_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_ListaVacio_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            List<int> listaPlaylist = new List<int>();
            sistema.AltaCancion(cancion, listaPlaylist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_ListaNula_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            sistema.AltaCancion(cancion, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_AutorVacio_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Autor = "";
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_DescripcionVaciaInvalido_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Descripcion = "";
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_DuracionNegativa_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Duracion = -500;
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_LinkAudioVacio_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.LinkAudio = "";
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_TituloVacio_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Titulo = "";
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_TituloNulo_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Titulo = null;
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_AutorNulo_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Autor = null;
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_DescripcionNula_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Descripcion = null;
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_LinkAudioNulo_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.LinkAudio = null;
            sistema.AltaCancion(cancion);
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
            sistema.AltaCancion(cancion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void AltaCancion_CancionExistente_Excepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            Cancion cancion2 = DatosGlobalesMusica.CrearCancionDormir();
            sistema.AltaCancion(cancion);
            sistema.AltaCancion(cancion2);
        }

        [TestMethod]
        public void AltaCancion_CancionConCategoriasDePlayList_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            List<int> idsPlayLists = datosGlobalesMusica.GetPlayListIDRegistradasEn();
            Playlist playList = sistema.GetPlayList(idsPlayLists[0]);
            sistema.AltaCancion(cancion, idsPlayLists);
            bool tieneCategoriasPlayList = ((List<TipoCategoriaMusical>)playList.Categorias).
                TrueForAll
                (categoria => ((List<TipoCategoriaMusical>)cancion.CategoriaMusical)
                .Contains(categoria));
            Assert.IsTrue(tieneCategoriasPlayList);
        }

        [TestMethod]
        public void AltaCancion_CategoriasCancionNoSeActualizan_SinExcepcion()
        {
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            cancion.Titulo = "Estrellas";
            List<int> idsPlayLists = datosGlobalesMusica.GetPlayListIDRegistradasEn();
            sistema.AltaCancion(cancion, idsPlayLists);
            Cancion resultado = sistema.GetCancion(cancion.Titulo, cancion.Autor);
            bool tienenMismoLargo = resultado.CategoriaMusical.Count == cancion.CategoriaMusical.Count;
            Assert.IsTrue(tienenMismoLargo);
        }
    }
}
