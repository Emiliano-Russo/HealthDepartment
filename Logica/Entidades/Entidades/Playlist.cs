using Entidades.Entidades;
using Entidades.Indices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Playlist")]
    public class Playlist
    {
        public Playlist()
        {
            this.canciones = new List<Cancion>();
            this.videos = new List<Video>();
            this.Categorias = new List<TipoCategoriaMusical>();
        }

        private List<Cancion> canciones;

        private List<Video> videos;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nombre { get; set; }
       
        public string Descripcion { get; set; }

        public string LinkImagen { get; set; }

        [NotMapped]
        public IReadOnlyCollection<Cancion> Canciones
        {
            get
            {
                return canciones;
            }
        }

        [NotMapped]
        public IReadOnlyCollection<Video> Videos 
        { 
            get
            {
                return videos;
            }
        }

        [NotMapped]
        public IReadOnlyCollection<TipoCategoriaMusical> Categorias { get; set; }

        public void AgregarCategoria(CategoriaMusical categoria)
        {
            List<TipoCategoriaMusical> lista = (List<TipoCategoriaMusical>)Categorias;
            TipoCategoriaMusical tipo = new TipoCategoriaMusical(categoria);
            if (!lista.Contains(tipo))
                lista.Add(tipo);
            this.Categorias = lista;
        }

        public void SustituirListaCategoriaMusical(List<CategoriaMusical> lista)
        {
            List<TipoCategoriaMusical> listaTipoCategoria = new List<TipoCategoriaMusical>();
            foreach (CategoriaMusical categoria in lista)
            {
                TipoCategoriaMusical tipo = new TipoCategoriaMusical(categoria);
                listaTipoCategoria.Add(tipo);
            }
            this.Categorias = listaTipoCategoria;
        }

        public void AgregarCancion(Cancion cancion)
        {
           cancion = SumarCategoriaFaltanteParaCancion(cancion);
           this.canciones.Add(cancion);
        }

        public void AgregarVideo(Video video)
        {
            video = SumarCategoriaFaltanteParaVideo(video);
            this.videos.Add(video);
        }
    
        public void SustituirListaCancion(List<Cancion> listaCancion)
        {
            if (listaCancion == null)
                return;
            if (listaCancion.Count == 0)
                this.canciones = listaCancion;
            foreach (Cancion cancion in listaCancion)
            {
                AgregarCancion(cancion);
            }
        }

        public void SustituirListVideos(List<Video> listaVideos)
        {
            if (listaVideos == null)
                return;
            if (listaVideos.Count == 0)
                this.videos = listaVideos;
            foreach (Video video in listaVideos)          
                AgregarVideo(video);           
        }

        private Cancion SumarCategoriaFaltanteParaCancion(Cancion cancion)
        {
            if (this.Categorias == null)
                return cancion;
            foreach (TipoCategoriaMusical tipoCategoria in this.Categorias)           
                    cancion.AgregarCategoria(tipoCategoria.Musical);
            
            return cancion;
        }

        private Video SumarCategoriaFaltanteParaVideo(Video video)
        {
            if (this.Categorias == null)
                return video;
            foreach (TipoCategoriaMusical tipoCategoria in this.Categorias)           
                video.AgregarCategoria(tipoCategoria.Musical);
            
            return video;
        }

        public bool EsVacia()
        {
            if (Nombre == null || Descripcion == null || canciones == null || Categorias == null)
                return true;
            else 
                return false;
        }

        public Playlist Clon()
        {
            Playlist playlist = new Playlist
            {
                ID = this.ID,
                Categorias = this.Categorias,
                Descripcion = this.Descripcion,
                Nombre = this.Nombre,
                videos = this.videos,
                LinkImagen = this.LinkImagen
            };
            List<Cancion> lista = (List<Cancion>)this.Canciones;
            playlist.SustituirListaCancion(lista);
            return playlist;
        }
    }
}