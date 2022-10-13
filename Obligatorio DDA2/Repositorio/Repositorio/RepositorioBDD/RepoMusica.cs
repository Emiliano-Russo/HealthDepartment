using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Entidades.Entidades;
using Entidades.Indices;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositorio.Logica;
using Repositorio.Repositorio.RepositorioBDD.Entidades;
using Repositorio.Repositorio.RepositorioBDD.Logica;
using Web.Api.Entidades;

namespace Repositorio.Repositorio.RepositorioBDD
{
    internal class RepoMusica
    {
        private LogicaRepoMusica logica;
        private DbContextOptions<EntidadesContexto> opciones;

        public RepoMusica(DbContextOptions<EntidadesContexto> opciones)
        {
            logica = new LogicaRepoMusica();
            this.opciones = opciones;
        }

        internal void RegistrarGaleriaMusical(GaleriaMusical galeriaMusical)
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                contexto.GaleriasMusicales.Add(galeriaMusical);
                foreach (Playlist playlist in galeriaMusical.PlayLists)
                    logica.AltaPlayList(playlist, contexto);

                foreach (Cancion cancion in galeriaMusical.Canciones)
                    logica.RegistrarCancion(cancion, contexto);

                foreach (Video video in galeriaMusical.Videos)
                    logica.RegistrarVideo(video, contexto);

                contexto.SaveChanges();
            }
        }

        internal int RegistrarPlaylist(Playlist playlist)
        {
            int idPlayList = 0;
            playlist = playlist.Clon();
            using (var contexto = new EntidadesContexto(opciones))
            {
                idPlayList = logica.AltaPlayList(playlist, contexto);
                contexto.SaveChanges();
            }
            return idPlayList;
        }

        internal int AltaVideo(Video video)
        {
            int idVideo = 0;
            using (var contexto = new EntidadesContexto(opciones))
            {
                idVideo = logica.RegistrarVideo(video, contexto);
            }
            return idVideo;
        }

        internal List<Playlist> GetTodasLasPlayLists()
        {
            List<Playlist> playLists = new List<Playlist>();
            using (var contexto = new EntidadesContexto(opciones))
            {
                List<Playlist> todasPlayLists = contexto.PlayList.ToList();
                if (todasPlayLists == null) return playLists;
                foreach (Playlist playList in todasPlayLists)
                {
                    Playlist playListConCancionesCategorias = logica.TraerPlayList(playList.ID, contexto);
                    playLists.Add(playListConCancionesCategorias);
                }
            }
            return playLists;
        }

        internal void BorrarTodosLosDatos()
        {
            using(var contexto = new EntidadesContexto(opciones))
            {
                contexto.Database.EnsureDeleted();
                contexto.SaveChanges();
            }
        }

        internal void BajaVideo(int index)
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                Video video = contexto.Videos.Single(x => x.ID == index);
                int idVideo = video.ID;
                contexto.Videos.Remove(video);
                logica.RemoverIndiceVideo(idVideo, contexto);
                contexto.SaveChanges();
            }
        }

        internal bool ExisteVideo(string linkVideo)
        {
            bool existe = false;
            using (var contexto = new EntidadesContexto(opciones))
            {
                List <Video> lista = contexto.Videos.ToList();
                existe = lista.Exists(x => x.LinkVideo == linkVideo);              
            }
            return existe;
        }

        internal bool ExisteVideo(Video video)
        {
            return ExisteVideo(video.LinkVideo);
        }

        internal Playlist GetPlayList(int id)
        {
            Playlist playlist = null;
            using (var contexto = new EntidadesContexto(opciones))
            {
                playlist = logica.TraerPlayList(id, contexto);
            }
            return playlist;
        }

        internal Cancion GetCancion(string titulo, string autor)
        {
            Cancion cancion = new Cancion();
            using (var contexto = new EntidadesContexto(opciones))
            {
                List<Cancion> listaCanciones = contexto.Canciones.ToList();
                cancion = listaCanciones.Find(x => x.Autor == autor && x.Titulo == titulo);
                if (cancion == null) return new Cancion();
                cancion.SustituirListaCategorias(logica.GetListaCategoria(cancion.ID, contexto));              
                List<CategoriaMusical> listaCategorias = logica.GetListaCategoria(cancion.ID, contexto);
                cancion.SustituirListaCategorias(listaCategorias);
            }
            return cancion;
        }

        internal List<Cancion> GetTodasLasCanciones()
        {
            List<Cancion> retorno = new List<Cancion>();
            using (var contexto = new EntidadesContexto(opciones))
            {
                retorno = contexto.Canciones.ToList();
                foreach (Cancion cancion in retorno)
                {
                    List<CategoriaMusical> listaCategorias = logica.GetListaCategoria(cancion.ID, contexto);
                    cancion.SustituirListaCategorias(listaCategorias);
                }
            }
            return retorno;
        }

        internal List<Video> GetTodosLosVideos()
        {
            List<Video> retorno = new List<Video>();
            using (var contexto = new EntidadesContexto(opciones))
            {
                retorno = contexto.Videos.ToList();

                foreach (Video video in retorno)
                {
                    List<CategoriaMusical> listaCategorias = logica.GetListaCategoriaVideo(video.ID, contexto);
                    video.SustituirListaCategorias(listaCategorias);
                }
               
            }
            return retorno;
        }

        internal List<CategoriaMusical> GetCategoriasMusicales()
        {
            return Enum.GetValues(typeof(CategoriaMusical)).Cast<CategoriaMusical>().ToList();
        }

        internal GaleriaMusical GetGaleriaMusical(CategoriaMusical categoria)
        {
            GaleriaMusical galeria = new GaleriaMusical();
            using (var contexto = new EntidadesContexto(opciones))
            {
                List<Playlist> listaPlayList = logica.ArmarPlayListsGaleria(contexto, categoria);
                List<Cancion> listaCanciones = logica.ArmarCancionesGaleria(contexto, categoria);
                List<Video> listaVideos = logica.ArmarVideoGaleria(contexto, categoria);
                logica.FiltrarCancioneSueltas(ref listaPlayList, ref listaCanciones);
                logica.FiltrarVideosSueltos(ref listaPlayList, ref listaVideos);
                galeria.CategoriaMusical = categoria;
                galeria.Canciones = listaCanciones;
                galeria.PlayLists = listaPlayList;
                galeria.Videos = listaVideos;
            }
            return galeria;
        }

        internal void SumarDatosGaleriaMusical(GaleriaMusical galeriaDatos)
        {
            OperacionesMusica op = new OperacionesMusica();
            List<Playlist> listaPlayList = this.GetTodasLasPlayLists();
            List<Cancion> listaCancion = this.GetTodasLasCanciones();
            List<Video> listaVideos = this.GetTodosLosVideos();

            this.FiltrarDatosExistente(ref galeriaDatos, listaPlayList);
            this.FiltrarDatosExistente(ref galeriaDatos, listaCancion);
            this.FiltrarDatosExistente(ref galeriaDatos, listaVideos);
            this.RegistrarDatos(galeriaDatos);
        }

        private void RegistrarDatos(GaleriaMusical galeriaDatos)
        {
            foreach (var playlist in galeriaDatos.PlayLists)
                this.RegistrarPlaylist(playlist);

            foreach (var cancion in galeriaDatos.Canciones)
                this.AltaCancion(cancion);

            foreach (var video in galeriaDatos.Videos)
                this.AltaVideo(video);
        }

        private void FiltrarDatosExistente(ref GaleriaMusical galeriaDatos, List<Playlist> listaPlayList)
        {
            foreach (var playlist in galeriaDatos.PlayLists)
                if (listaPlayList.Contains(playlist))
                    galeriaDatos.PlayLists.Remove(playlist);
        }
        private void FiltrarDatosExistente(ref GaleriaMusical galeriaDatos, List<Cancion> listaCancion)
        {
            foreach (var cancion in galeriaDatos.Canciones)
                if (listaCancion.Contains(cancion))
                    galeriaDatos.Canciones.Remove(cancion);
        }

        private void FiltrarDatosExistente(ref GaleriaMusical galeriaDatos, List<Video> listaVideos)
        {
            foreach (var video in galeriaDatos.Videos)
                if (listaVideos.Contains(video))
                    galeriaDatos.Videos.Remove(video);
        }


        internal Video GetVideo(int index)
        {
            Video video = new Video();
            using (var contexto = new EntidadesContexto(opciones))
            {
                List<Video> listaVideos = contexto.Videos.ToList();
                video = listaVideos.Find(x => x.ID == index);
                if (video == null) return new Video();
                List<CategoriaMusical> lista = logica.GetListaCategoriaVideo(video.ID, contexto);               
                video.SustituirListaCategorias(lista);             
                List<CategoriaMusical> listaCategorias = logica.GetListaCategoriaVideo(video.ID, contexto);
                video.SustituirListaCategorias(listaCategorias);
            }
            return video;
        }

        internal bool ExistePlayList(int id)
        {
            bool existe = false;
            using (var contexto = new EntidadesContexto(opciones))
            {
                Playlist playlist = contexto.PlayList.Find(id);
                existe = playlist != null;
            }
            return existe;
        }

        internal void BajaCancion(string titulo, string autor)
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                Cancion cancion = contexto.Canciones.Single(x => x.Titulo == titulo && x.Autor == autor);
                int idCancion = cancion.ID;
                contexto.Canciones.Remove(cancion);
                logica.RemoverIndicesCancion(idCancion, contexto);
                contexto.SaveChanges();
            }
        }


        internal int AltaVideo(Video video, List<int> idPlayLists)
        {
            video = video.Clon();
            int idVideo = 0;
            using (var contexto = new EntidadesContexto(opciones))
            {
                idVideo = logica.RegistrarVideo(video, contexto);
                foreach (int idPlayList in idPlayLists)
                {
                    IXVideoPlayList ind = new IXVideoPlayList(idVideo, idPlayList);
                    contexto.IndiceVideoPlayList.Add(ind);
                }
                contexto.SaveChanges();
            }
            return idVideo;
        }


        internal int AltaCancion(Cancion cancion, List<int> idPlaylists)
        {
            cancion = cancion.Clon();
            int idCancion = 0;
            using (var contexto = new EntidadesContexto(opciones))
            {
                idCancion = logica.RegistrarCancion(cancion, contexto);
                foreach (int idPlayList in idPlaylists)
                {
                    IXCancionPlayList ind = new IXCancionPlayList(idCancion, idPlayList);
                    contexto.IndiceCancionPlayList.Add(ind);
                }
                contexto.SaveChanges();
            }
            return idCancion;
        }

        internal int AltaCancion(Cancion cancion)
        {
            cancion = cancion.Clon();
            int idCancion = 0;
            using (var contexto = new EntidadesContexto(opciones))
            {
                idCancion = logica.RegistrarCancion(cancion, contexto);
            }
            return idCancion;
        }
    }
}
