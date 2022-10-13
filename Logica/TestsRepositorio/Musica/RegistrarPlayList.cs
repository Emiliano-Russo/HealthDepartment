using Entidades;
using Entidades.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {
        [TestMethod]
        public void RegistrarPlaylist_DatosCorrectos_IDMayorACero()
        {
            List<Cancion> listaCanciones = datosGlobalesMusica.GetListaCancionesMeditarRegistradasEnSinPlayList();
            List<CategoriaMusical> listaCategorias = new List<CategoriaMusical>();
            listaCategorias.Add(CategoriaMusical.Meditar);
            listaCategorias.Add(CategoriaMusical.Dormir);
            Video video = new Video();
            video.SustituirListaCategorias(listaCategorias);            
            Playlist playList = new Playlist
            {
                Nombre = "Relax",
                Descripcion = "Mejor playlist para quitarse el estres",
                Categorias = opMusica.Transformar(listaCategorias)
            };
            playList.SustituirListaCancion(listaCanciones);
            int ID = repositorio.RegistrarPlaylist(playList);
            Assert.IsTrue(ID >= 0);
            Playlist retorno = repositorio.GetPlayList(ID);
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
            int ID = repositorio.RegistrarPlaylist(playList);
            int ID2 = repositorio.RegistrarPlaylist(playList);
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
            int id = repositorio.RegistrarPlaylist(playlist);
            playlist = repositorio.GetPlayList(id);
            Assert.IsTrue(playlist.Canciones.Count == 0);
        }
    }
}
