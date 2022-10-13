using Entidades.Indices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Entidades
{
    [Table("Cancion")]
    public class Cancion
    {
        public Cancion()
        {
            this.CategoriaMusical = new List<TipoCategoriaMusical>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public float Duracion { get; set; }

        public string Autor { get; set; }

        public string LinkAudio { get; set; }

        public string LinkImagen { get; set; }

        [NotMapped]
        public IReadOnlyCollection<TipoCategoriaMusical> CategoriaMusical { get; set; }

        public void AgregarCategoria(CategoriaMusical categoria)
        {
            List<TipoCategoriaMusical> lista = (List<TipoCategoriaMusical>)this.CategoriaMusical;
            TipoCategoriaMusical tipo = new TipoCategoriaMusical(categoria);
            if (!lista.Contains(tipo))
                lista.Add(tipo);
            this.CategoriaMusical = lista;
        }
      
        public bool Equals([AllowNull] Cancion other)
        {
            return other != null && other.ID == this.ID && other.Autor == this.Autor && other.Titulo == this.Titulo;
        }

        public bool EsVacia()
        {
            return this.Titulo == null || this.Descripcion == null ||
                this.Autor == null || this.LinkAudio == null ||
                this.LinkImagen == null || CategoriaMusical == null;
        }

        public Cancion Clon()
        {
            Cancion cancion = new Cancion
            {
                ID = this.ID,
                Autor = this.Autor,
                CategoriaMusical = this.CategoriaMusical,
                Descripcion = this.Descripcion,
                Duracion = this.Duracion,
                LinkAudio = this.LinkAudio,
                LinkImagen = this.LinkImagen,

                Titulo = this.Titulo
            };

            return cancion;
        }

        public void SustituirListaCategorias(List<CategoriaMusical> listaCategorias)
        {
            List<TipoCategoriaMusical> listaTipo = new List<TipoCategoriaMusical>();
            foreach (CategoriaMusical categoria in listaCategorias)
            {
                TipoCategoriaMusical tipo = new TipoCategoriaMusical(categoria);
                listaTipo.Add(tipo);
            }
            this.CategoriaMusical = listaTipo;
        }
    }
}