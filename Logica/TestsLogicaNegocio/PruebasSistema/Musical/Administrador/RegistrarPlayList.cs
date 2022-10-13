using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;
using Entidades.Indices;
using Entidades.Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void RegistrarPlaylist_DatosCorrectos_IDMayorACero()
        {
            List<Cancion> listaCanciones = datosGlobalesMusica.GetListaCancionesMeditarRegistradasEnSinPlayList();
            List<CategoriaMusical> listaCategorias = new List<CategoriaMusical>();
            listaCategorias.Add(CategoriaMusical.Meditar);
            listaCategorias.Add(CategoriaMusical.Dormir);
            Playlist playList = new Playlist
            {
                Nombre = "Relax",
                Descripcion = "Mejor playlist para quitarse el estres",
                Categorias = opMusica.Transformar(listaCategorias)
            };
            playList.SustituirListaCancion(listaCanciones);
            int ID = sistema.RegistrarPlaylist(playList);
            Assert.IsTrue(ID >= 0);
            Playlist retorno = sistema.GetPlayList(ID);
            bool mismoAtributos = opMusica.MismosAtributos(retorno, playList);
            Assert.IsTrue(mismoAtributos);
        }

        [TestMethod]
        public void RegistrarPlaylist_DatosCorrectos2_DiferenteID()
        {
            List<Cancion> listaCanciones = datosGlobalesMusica.GetListaCancionesMeditarRegistradasEnSinPlayList();
            List<CategoriaMusical> listaCategoiras = new List<CategoriaMusical>();
            listaCategoiras.Add(CategoriaMusical.Musica);
            Playlist playList = new Playlist
            {
                Nombre = "Relax",
                Descripcion = "Mejor playlist para quitarse el estres",
                Categorias = opMusica.Transformar(listaCategoiras)
            };
            playList.SustituirListaCancion(listaCanciones);
            Playlist playList2 = new Playlist
            {
                Nombre = "Calido",
                Descripcion = "La mejor para relajarte",
                Categorias = opMusica.Transformar(listaCategoiras)
            };
            playList.SustituirListaCancion(listaCanciones);
            int ID = sistema.RegistrarPlaylist(playList);
            int ID2 = sistema.RegistrarPlaylist(playList);
            Assert.IsTrue(ID != ID2);
            bool existePlayList1 = opMusica.ExistePlayListEn(ID);
            bool existePlayList2 = opMusica.ExistePlayListEn(ID2);
            Assert.IsTrue(existePlayList1);
            Assert.IsTrue(existePlayList2);
        }

        [TestMethod]
        public void RegistrarPlaylist_SinCanciones_SinExcepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            List<Cancion> sinCanciones = new List<Cancion>();
            playlist.SustituirListaCancion(sinCanciones);
            int id = sistema.RegistrarPlaylist(playlist);
            playlist = sistema.GetPlayList(id);
            Assert.IsTrue(playlist.Canciones.Count == 0);
        }

        [TestMethod]
        public void RegistrarPlaylist_Video_SinExcepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.SustituirListaCancion(new List<Cancion>());
            List<Video> videos = DatosGlobalesMusica.GetListaVideos();
            playlist.AgregarVideos(videos);
            int id = sistema.RegistrarPlaylist(playlist);
            Playlist resultado = sistema.GetPlayList(id);
            Assert.IsTrue(resultado.Videos.Count == DatosGlobalesMusica.GetListaVideos().Count);
        }
     
        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_DescripcionVacia_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Descripcion = "";
            sistema.RegistrarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_NombreVacio_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Nombre = "";
            sistema.RegistrarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_DescripcionNula_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Descripcion = null;
            sistema.RegistrarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_NombreNulo_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.Nombre = null;
            sistema.RegistrarPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionMusica))]
        public void RegistrarPlaylist_ListaCancionesNula_Excepcion()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.SustituirListaCancion(null);
            sistema.RegistrarPlaylist(playlist);
        }

        // ----
        [TestMethod]
        public void PlaylistCategorias_Cancion_SeActualizanSusCategorias()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            playlist.AgregarCategoria(CategoriaMusical.Cuerpo);
            Cancion cancion = DatosGlobalesMusica.CrearCancionDormir();
            List<CategoriaMusical> listaCategoria = opMusica.Transformar((List<TipoCategoriaMusical>)cancion.CategoriaMusical);
            Assert.IsFalse(listaCategoria.Contains(CategoriaMusical.Cuerpo));
            playlist.AgregarCancion(cancion);         
            cancion = ((List<Cancion>)playlist.Canciones).Find(c =>
            c.Titulo == cancion.Titulo && c.Autor == cancion.Autor);
            listaCategoria = opMusica.Transformar((List<TipoCategoriaMusical>)cancion.CategoriaMusical);
            Assert.IsTrue(listaCategoria.Contains(CategoriaMusical.Cuerpo));
        }

        [TestMethod]
        public void PlaylistCategorias_Cancion_NoSeActualizan()
        {
            Playlist playlist = DatosGlobalesMusica.CrearPlayListMeditacion();
            Cancion cancion = DatosGlobalesMusica.CrearCancionMeditar();
            List<CategoriaMusical> listaCategoria = opMusica.Transformar((List<TipoCategoriaMusical>)cancion.CategoriaMusical);
            Assert.IsTrue(listaCategoria.Contains(CategoriaMusical.Meditar));
            playlist.AgregarCancion(cancion);
            List<Cancion> lista = (List<Cancion>)playlist.Canciones;
              cancion = lista.Find(c =>
            c.Titulo == cancion.Titulo && c.Autor == cancion.Autor);
            listaCategoria = opMusica.Transformar((List<TipoCategoriaMusical>)cancion.CategoriaMusical);
            Assert.IsTrue(listaCategoria.Contains(CategoriaMusical.Meditar));
            Assert.IsTrue(cancion.CategoriaMusical.Count == 1);
        }


    }
}
