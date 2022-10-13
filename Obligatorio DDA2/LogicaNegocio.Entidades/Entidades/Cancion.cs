using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LogicaNegocio
{
    //Clave compuesta Titulo + Autor
    public class Cancion 
    {
        public int ID { get; set; }
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public float Duracion { get; set; }

        public string Autor { get; set; }

        public string LinkAudio { get; set; }

        public string LinkImagen { get; set; }

        public List<CategoriaMusical> CategoriaMusical { get; set; }

        public bool Equals([AllowNull] Cancion other)
        {
            return other != null && other.Autor == this.Autor && other.Titulo == this.Titulo;
        }

        //Refactoreo
        public bool EsVacia()
        {
            return this.Titulo == null || this.Descripcion == null || 
                this.Autor == null || this.LinkAudio ==null ||
                this.LinkImagen == null || CategoriaMusical == null;
        }
    }
}