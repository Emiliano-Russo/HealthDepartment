using Entidades;
using Entidades.Indices;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Api.Entidades.Presentacion;

namespace Utilidades.OperacionesEntidades
{
    public class OperacionesMusica
    {
        private IRepositorio repositorio;
        public OperacionesMusica(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public bool MismosAtributos(Playlist playlistX, Playlist playlistZ)
        {
            if (playlistX == null && playlistZ == null)
                return true;
            bool mismoNombre = playlistX.Nombre == playlistZ.Nombre;
            bool mismaDescripcion = playlistX.Descripcion == playlistZ.Descripcion;
            List<Cancion> cancionesX = (List<Cancion>)playlistX.Canciones;
            List<Cancion> cancionesZ = (List<Cancion>)playlistZ.Canciones;
            bool mismasCanciones = MismosAtributos(cancionesX, cancionesZ);
            return mismoNombre && mismaDescripcion && mismasCanciones;
        }

        public bool MismosAtributos(Playlist playlist, PlaylistExhibicion resultado)
        {
            bool mismoID = playlist.ID == resultado.ID;
            bool mismoNombre = playlist.Nombre == resultado.Nombre;
            bool mismaDescripcion = playlist.Descripcion == resultado.Descripcion;
            return mismoID && mismoNombre && mismaDescripcion;
        }

        public bool MismosAtributos(Cancion cancionEstandar, CancionExhibicion cancion)
        {
            bool mismoAutor = cancionEstandar.Autor == cancion.Autor;
            bool mismoTitulo = cancionEstandar.Titulo == cancion.Titulo;
            bool mismaDescripcion = cancionEstandar.Descripcion == cancion.Descripcion;
            bool mismoID = cancionEstandar.ID == cancion.ID;
            bool mismoLinkAudio = cancionEstandar.LinkAudio == cancion.LinkAudio;
            bool mismoLinkImagen = cancionEstandar.LinkImagen == cancion.LinkImagen;
            return mismoAutor && mismoLinkImagen
                              && mismaDescripcion && mismoID
                              && mismoTitulo && mismoLinkAudio;
        }

        public bool MismosAtributos(List<Cancion> listaX, List<Cancion> listaZ)
        {
            if (listaX == null && listaZ == null)
                return true;
            if (listaX.Count != listaZ.Count)
                return false;

            bool iguales = true;
            for (int i = 0; i < listaX.Count; i++)
            {
                iguales = iguales && MismosAtributos(listaX[i], listaZ[i]);
            }
            return iguales;
        }

        public IReadOnlyCollection<TipoCategoriaMusical> Transformar(List<CategoriaMusical> lista)
        {
            List<TipoCategoriaMusical> retorno = new List<TipoCategoriaMusical>();
            foreach (CategoriaMusical categoria in lista)
            {
                TipoCategoriaMusical tipo = new TipoCategoriaMusical(categoria);
                retorno.Add(tipo);
            }
            return retorno;
        }

        public bool MismosAtributos(Cancion cancionX, Cancion cancionZ)
        {
            bool mismoAutor = cancionX.Autor == cancionZ.Autor;
            bool mismoTitulo = cancionX.Titulo == cancionZ.Titulo;
            return mismoAutor && mismoTitulo;
        }


        public bool ExisteCancionEnSistema(string titulo, string autor)
        {
            Cancion cancion = repositorio.GetCancion(titulo, autor);
            if (cancion.EsVacia())
                return false;
            else
                return true;
        }



        public bool ExistePlayListEn(int ID)
        {
            try
            {
                repositorio.GetPlayList(ID);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool MismaLista(List<Playlist> listaPlaylist, List<Playlist> listaPlaylist2)
        {
            bool mismaLista = true;
            if (listaPlaylist == null && listaPlaylist2 == null)
                return true;
            if (listaPlaylist.Count != listaPlaylist2.Count)
                return false;

            for (int i = 0; i < listaPlaylist.Count; i++)
            {
                try
                {
                    mismaLista = mismaLista && MismosAtributos(listaPlaylist[i], listaPlaylist2[i]);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return mismaLista;
        }

    }
}
