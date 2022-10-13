using Entidades;
using Entidades.Entidades;
using Interfaces;
using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Api.Administracion;
using Web.Api.Entidades;
using Web.Api.Entidades.Presentacion;

namespace Obligatorio_DDA2.Controllers
{
    public class MusicaController : Controller
    {

        private ISistema sistema;
        private Direccion direccion;

        public MusicaController(ISistema sistema)
        {
            this.sistema = sistema;
            direccion = new Direccion(this);
        }

        public JsonResult Index()
        {
            List<CategoriaMusical> lista = sistema.GetCategoriasMusicales();
            List<string> presentacion = direccion.ConversionAExhibicion(lista);
            return direccion.Respuesta(presentacion);
        }

        [HttpGet]
        public JsonResult GetGaleriaMusical(CategoriaMusical categoria)
        {
            GaleriaMusical galeria = sistema.GetGaleriaMusical(categoria);
            GaleriaMusicalExhibicion presentacion = direccion.ConversionAExhibicion(galeria);
            return direccion.Respuesta(presentacion);
        }
        
        [HttpGet]
        public JsonResult GetPlayList(int id)
        {
            try
            {
                Playlist playlist = sistema.GetPlayList(id);
                PlaylistExhibicion presentacion = direccion.ConversionAExhibicion(playlist);
                return direccion.Respuesta(presentacion);
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpGet]
        public JsonResult GetTodasLasPlayList()
        {
            List<Playlist> lista = sistema.GetTodasLasPlayList();
            List<PlaylistExhibicion> presentacion = direccion.ConversionAExhibicion(lista);
            return direccion.Respuesta(presentacion);
        }


        [HttpPost]
        public JsonResult RegistrarPlayList([FromBody] Playlist playlist, [FromHeader] string token)
        {
            List<Cancion> canciones = Fix.Canciones;
            List<Video> videos = Fix.Videos;
            Fix.Canciones = null;
            Fix.Videos = null;
            playlist.SustituirListaCancion(canciones);
            playlist.SustituirListVideos(videos);
            
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    int id = sistema.RegistrarPlaylist(playlist);
                    return direccion.Respuesta(id);
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }

            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpPost]
        public void RegistrarPlayListCancion([FromBody] ListaCanciones lista)
        {
            Fix.Canciones = lista.Canciones;
        }

        [HttpPost]
        public void RegistrarPlayListVideo([FromBody] ListaVideos lista)
        {
            Fix.Videos = lista.Videos;
        }

        [HttpGet]
        public JsonResult GetCancion(string titulo, string autor)
        {
            try
            {
                Cancion cancion = sistema.GetCancion(titulo, autor);
                CancionExhibicion presentacion = direccion.ConversionAExhibicion(cancion);
                return direccion.Respuesta(presentacion);
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }


        [HttpPost]
        public JsonResult RegistrarCancionConPlayLists([FromBody] CancionPlayList CancionPlayList, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    if (CancionPlayList == null)
                        CancionPlayList = new CancionPlayList();
                    sistema.AltaCancion(CancionPlayList.Cancion, CancionPlayList.IdPlayLists);
                    return direccion.Respuesta("Cancion Registrada!");
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        public JsonResult RegistrarVideoConPlayLists([FromBody] VideoPlayList VideoPlayList, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.AltaVideo(VideoPlayList.Video, VideoPlayList.IdPlayLists);
                    return direccion.Respuesta("Video Registrado!");
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpPost]
        public JsonResult RegistrarVideo([FromBody] Video video, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    int id = sistema.AltaVideo(video);
                    return direccion.Respuesta(id);
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e.Message);
            }
        }

        [HttpPost]
        public JsonResult RegistrarCancion([FromBody] Cancion cancion, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.AltaCancion(cancion);
                    return direccion.Respuesta("Cancion guardada");
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpDelete]
        public JsonResult BorrarCancion([FromBody] CancionIdentificar cancionIdentificada, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.BajaCancion(cancionIdentificada.Titulo, cancionIdentificada.Autor);
                    return direccion.Respuesta("Cancion borrada");
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpGet]
        public JsonResult GetTodasLasCanciones()
        {
            try
            {
                List<Cancion> lista = sistema.GetTodasLasCanciones();
                return direccion.Respuesta(lista);
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e.Message);
            }
        }

        [HttpGet]
        public JsonResult GetTodosLosVideos()
        {
            try
            {
                List<Video> lista = sistema.GetTodosLosVideos();
                return direccion.Respuesta(lista);
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e.Message);
            }
        }

        [HttpDelete]
        public JsonResult BorrarVideo([FromBody] int id, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.BajaVideo(id);
                    return direccion.Respuesta("Video Borrado");
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e.Message);
            }
        }

        [HttpGet]
        public JsonResult GetTodasLasImportaciones()
        {
            try
            {
                List<string> lista = sistema.GetNombresImportadores();
                return Json(lista);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }


        [HttpPost]
        public JsonResult SubirArchivo([FromForm] IFormFile archivo, [FromHeader] string tipoArchivo, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    string ruta = "C:\\Users\\Public\\ArchivosTexto\\" + archivo.FileName;
                    using (var fileStream = new FileStream(ruta, FileMode.Create, FileAccess.Write))
                    {
                        archivo.CopyTo(fileStream);
                    }
                    sistema.LeerArchivo(ruta, tipoArchivo);
                    return Json("Archivo subido");
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

    }
}
