using Entidades;
using Entidades.Entidades;
using Entidades.Indices;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilidades
{
    public class DatosGlobalesMusica
    {
        private IRepositorio repositorio;
        public DatosGlobalesMusica(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public static Cancion CancionDatosCorrectos()
        {
            return new Cancion
            {
                Titulo = "Musica motivadora",
                Descripcion = "musica para despertarse con energia para el trabajo",
                Duracion = 1200,
                Autor = "Ricardo mencholato",
                LinkAudio = "musica_motivadora.com",
                LinkImagen = "imagen_musica_relajante.com",
                CategoriaMusical = CategoriasMusicalesEstandar(),
            };
        }

        public static Video CrearVideoCatCuerpo()
        {
            Video video = new Video
            {
                Nombre = "Video Musical",
                Autor = "Jorge",
                DuracionMins = 100,
                LinkVideo = "www.youtube.com/asd7e1cs",
            };
            video.AgregarCategoria(CategoriaMusical.Cuerpo);

            return video;
        }

        private static List<TipoCategoriaMusical> CategoriasMusicalesEstandar()
        {
            List<TipoCategoriaMusical> categorias = new List<TipoCategoriaMusical>();
            categorias.Add(new TipoCategoriaMusical(CategoriaMusical.Cuerpo));
            categorias.Add(new TipoCategoriaMusical(CategoriaMusical.Dormir));
            return categorias;
        }


        public static Cancion CrearCancionMeditar()
        {
            List<TipoCategoriaMusical> listaCategoriaMusical = new List<TipoCategoriaMusical>();
            listaCategoriaMusical.Add(new TipoCategoriaMusical(CategoriaMusical.Meditar));
            Cancion cancion = new Cancion
            {
                Autor = "Jorge",
                Descripcion = "Buena Musica para meditar y encontrar paz interior",
                CategoriaMusical = listaCategoriaMusical,
                Duracion = 5000,
                LinkAudio = "www.musica.com/MeditarJorge",
                LinkImagen = "",
                Titulo = "Vida tranquila"
            };
            return cancion;
        }

        public static Cancion CrearCancionDormir()
        {
            List<TipoCategoriaMusical> listaCategoriaMusical = new List<TipoCategoriaMusical>();
            listaCategoriaMusical.Add(new TipoCategoriaMusical(CategoriaMusical.Dormir));
            Cancion cancion = new Cancion
            {
                Autor = "Maxi",
                Descripcion = "Musica para despejar la mente",
                CategoriaMusical = listaCategoriaMusical,
                Duracion = 8000,
                LinkAudio = "www.musica.com/MaxiDormir",
                LinkImagen = "www.gyazo.com/asd",
                Titulo = "Horizonte"
            };
            return cancion;
        }

        public static Playlist CrearPlayListMeditacion()
        {
            List<Cancion> listaCanciones = new List<Cancion>();

            Cancion cancionMeditar = CrearCancionMeditar();
            listaCanciones.Add(cancionMeditar);

            cancionMeditar.Autor = "Felix";
            cancionMeditar.LinkAudio = "www.felixmusica.com";
            listaCanciones.Add(cancionMeditar);

            cancionMeditar.Autor = "Gonza";
            cancionMeditar.LinkAudio = "www.todomusicaGonza.com";
            listaCanciones.Add(cancionMeditar);
            List<TipoCategoriaMusical> listaCategorias = new List<TipoCategoriaMusical>();
            listaCategorias.Add(new TipoCategoriaMusical(CategoriaMusical.Meditar));

            Playlist playlist = new Playlist
            {
                Nombre = "Hits 2021",
                Descripcion = "La mejor playlista",
                Categorias = listaCategorias
            };
            playlist.SustituirListaCancion(listaCanciones);
            return playlist;
        }

        public Playlist CrearPlayListDormir()
        {
            List<Cancion> listaCanciones = new List<Cancion>();

            Cancion cancionDormir = CrearCancionDormir();
            cancionDormir.ID = repositorio.AltaCancion(cancionDormir);
            listaCanciones.Add(cancionDormir);
            List<TipoCategoriaMusical> listaCategorias = new List<TipoCategoriaMusical>();
            listaCategorias.Add(new TipoCategoriaMusical(CategoriaMusical.Meditar));

            Playlist playlist = new Playlist
            {
                Nombre = "Hits Globales",
                Descripcion = "Los mejores hits",
                Categorias = listaCategorias
            };
            playlist.SustituirListaCancion(listaCanciones);
            return playlist;
        }

        public List<int> GetPlayListIDRegistradasEn()
        {
            Cancion cancionDormir = CrearCancionDormir();
            repositorio.AltaCancion(cancionDormir);
            List<Cancion> canciones = new List<Cancion>();
            canciones.Add(cancionDormir);
            List<TipoCategoriaMusical> listaCategorias = new List<TipoCategoriaMusical>();
            listaCategorias.Add(new TipoCategoriaMusical(CategoriaMusical.Dormir));
            Playlist playlist = new Playlist
            {
                Nombre = "Meditacion Unica",
                Descripcion = "La mejor playlist para relajarte",
                Categorias = listaCategorias
            };
            playlist.SustituirListaCancion(canciones);
            int playListID = repositorio.RegistrarPlaylist(playlist);
            List<int> listaPlayLists = new List<int>();
            listaPlayLists.Add(playListID);
            return listaPlayLists;
        }

        public List<Cancion> GetListaCancionesMeditarRegistradasEnSinPlayList()
        {
            Cancion canionMeditar = CrearCancionMeditar();
            canionMeditar.ID = repositorio.AltaCancion(canionMeditar);
            List<Cancion> listaCanciones = new List<Cancion>();
            listaCanciones.Add(canionMeditar);
            return listaCanciones;
        }

    }
}
