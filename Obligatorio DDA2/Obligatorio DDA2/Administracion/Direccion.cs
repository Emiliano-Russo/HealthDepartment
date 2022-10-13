using Entidades;
using Entidades.Entidades;
using Entidades.Indices;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Api.Entidades.Presentacion;

namespace Web.Api.Administracion
{
    internal class Direccion
    {
        private Controller controlador;

        internal Direccion(Controller controlador)
        {
            this.controlador = controlador;
        }

        internal JsonResult Respuesta(object mensaje)
        {
            RespuestaJson respuesta = new RespuestaJson(mensaje);
            return respuesta.GetRespuesta(controlador);
        }

        internal JsonResult RespuestaSesionInactiva()
        {
            controlador.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            RespuestaJson respuesta = new RespuestaJson((int)HttpStatusCode.Forbidden, "No existe la sesion");
            return respuesta.GetRespuesta(controlador);
        }

        internal JsonResult Respuesta(Exception e)
        {
            RespuestaJson respuesta = new RespuestaJson(controlador.Response.StatusCode, e);
            return respuesta.GetRespuesta(controlador);
        }

               
        private string ConversionDuracion(float duracionSegundos)
        {
            float horaEnSegundos = 3600;
            if (duracionSegundos >= horaEnSegundos)
                return PresentarEnHoras(duracionSegundos);
            else
                return PresentarEnMinutos(duracionSegundos);
        }

        private string PresentarEnHoras(float segundos)
        {
            TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
            string answer = string.Format("{0:D2}h:{1:D2}m",
                tiempo.Hours,
                tiempo.Minutes);
            return answer;
        }

        private string PresentarEnMinutos(float segundos)
        {
            TimeSpan tiempo = TimeSpan.FromSeconds(segundos);
            string answer = string.Format("{0:D2}m:{1:D2}s",              
                tiempo.Minutes,
                tiempo.Seconds);
            return answer;
        }

        internal CancionExhibicion ConversionAExhibicion(Cancion cancion)
        {
            CancionExhibicion modelo = new CancionExhibicion
            {
                Autor = cancion.Autor,
                Descripcion = cancion.Descripcion,
                ID = cancion.ID,
                LinkAudio = cancion.LinkAudio,
                LinkImagen = cancion.LinkImagen,
                Titulo = cancion.Titulo,
                CategoriasMusicales = this.ConversionAExhibicion(cancion.CategoriaMusical),
                Duracion = this.ConversionDuracion(cancion.Duracion)
            };
            return modelo;
        }

        internal VideoExhibicion ConversionAExhibicion(Video video)
        {
            VideoExhibicion modelo = new VideoExhibicion
            {
                ID = video.ID,
                Autor = video.Autor,
                LinkVideo = video.LinkVideo,
                DuracionMins = video.DuracionMins,
                Nombre = video.Nombre,
                ListaCategorias = this.ConversionAExhibicion(video.Categorias)
            };
            return modelo;
        }

        internal List<CancionExhibicion> ConversionAExhibicion(List<Cancion> lista)
        {
            if (lista == null)
                return null;
            List<CancionExhibicion> retorno = new List<CancionExhibicion>();
            foreach (Cancion cancion in lista)
            {
                CancionExhibicion modelo = ConversionAExhibicion(cancion);
                retorno.Add(modelo);
            }
            return retorno;
        }

        internal PlaylistExhibicion ConversionAExhibicion(Playlist playlist)
        {
            PlaylistExhibicion modelo = new PlaylistExhibicion()
            {
                Canciones = this.ConversionAExhibicion((List<Cancion>)playlist.Canciones),
                Descripcion = playlist.Descripcion,
                ID = playlist.ID,
                ListaCategorias = this.ConversionAExhibicion(playlist.Categorias),
                Nombre = playlist.Nombre,
                Videos = this.ConversionAExhibicion((List<Video>)playlist.Videos),
                LinkImagen = playlist.LinkImagen
            };
            return modelo;
        }

        internal List<PlaylistExhibicion> ConversionAExhibicion(List<Playlist> lista)
        {
            if (lista == null)
                return null;
            List<PlaylistExhibicion> retorno = new List<PlaylistExhibicion>();
            foreach (Playlist playlist in lista)
            {
                PlaylistExhibicion modelo = ConversionAExhibicion(playlist);
                retorno.Add(modelo);
            }
            return retorno;
        }

        internal GaleriaMusicalExhibicion ConversionAExhibicion(GaleriaMusical galeria)
        {
            GaleriaMusicalExhibicion retorno = new GaleriaMusicalExhibicion
            {
                CategoriaMusical = Transformar(galeria.CategoriaMusical),
                Canciones = ConversionAExhibicion(galeria.Canciones),
                PlayLists = ConversionAExhibicion(galeria.PlayLists),
                Videos = ConversionAExhibicion(galeria.Videos)
            };
            return retorno;
        }

        internal string Transformar(CategoriaMusical categoria)
        {
            switch (categoria)
            {
                case CategoriaMusical.Dormir:
                    return "Dormir";
                    break;
                case CategoriaMusical.Meditar:
                    return "Meditar";
                    break;
                case CategoriaMusical.Musica:
                    return "Musica";
                    break;
                case CategoriaMusical.Cuerpo:
                    return "Cuerpo";
                    break;
                default:
                    return "Dormir";
                    break;
            }
        }

        internal List<VideoExhibicion> ConversionAExhibicion(List<Video> lista)
        {
            if (lista == null)
                return null;
            List<VideoExhibicion> retorno = new List<VideoExhibicion>();
            foreach (Video video in lista)
            {
                VideoExhibicion modelo = ConversionAExhibicion(video);
                retorno.Add(modelo);
            }
            return retorno;
        }

        internal List<string> ConversionAExhibicion(IReadOnlyCollection<TipoCategoriaMusical> lista)
        {
            if (lista == null)
                return null;
            List<string> retorno = new List<string>();
            List<CategoriaMusical> categorias = Transformar((List<TipoCategoriaMusical>)lista);
            foreach (CategoriaMusical categoria in categorias)
            {
                string categoriaString = Transformar(categoria);
                retorno.Add(categoriaString);
            }
            return retorno;
        }

        internal List<CategoriaMusical> Transformar(List<TipoCategoriaMusical> lista)
        {
            if (lista == null)
                return null;
            List<CategoriaMusical> retorno = new List<CategoriaMusical>();
            foreach (TipoCategoriaMusical tipo in lista)           
                retorno.Add(tipo.Musical);          
            return retorno;
        }

        internal List<string> ConversionAExhibicion(List<CategoriaMusical> lista)
        {
            if (lista == null)
                return null;
            List<string> retorno = new List<string>();
            foreach (CategoriaMusical item in lista)
            {
                string categoriaString = Transformar(item);
                retorno.Add(categoriaString);
            }
            return retorno;
        }
    }
}
