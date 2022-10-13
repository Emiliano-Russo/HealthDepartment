using Entidades.Indices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Entidades.Entidades
{
    [Table("Video")]
    public class Video
    {
        public Video()
        {
            Categorias = new List<TipoCategoriaMusical>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public int DuracionMins { get; set; }

        public string LinkVideo { get; set; }

        public string Autor { get; set; }

        [NotMapped]
        public IReadOnlyCollection<TipoCategoriaMusical> Categorias { get; set; }

        public void AgregarCategoria(CategoriaMusical categoria)
        {
            List<TipoCategoriaMusical> lista = (List<TipoCategoriaMusical>)this.Categorias;
            TipoCategoriaMusical tipo = new TipoCategoriaMusical(categoria);
            if (!lista.Contains(tipo))
                lista.Add(tipo);
            this.Categorias = lista;
        }

        public void SustituirListaCategorias(List<CategoriaMusical> listaCategorias)
        {
            List<TipoCategoriaMusical> listaTipo = new List<TipoCategoriaMusical>();
            foreach (CategoriaMusical categoria in listaCategorias)
            {
                TipoCategoriaMusical tipo = new TipoCategoriaMusical(categoria);
                listaTipo.Add(tipo);
            }
            this.Categorias = listaTipo;
        }

        public Video Clon()
        {
            Video video = new Video
            {
                ID = this.ID,
                Autor = this.Autor,
                LinkVideo = this.LinkVideo,
                Nombre = this.Nombre,
                DuracionMins = this.DuracionMins,
                Categorias = this.Categorias
            };
            return video;
        }
    }
}
