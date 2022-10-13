using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Entidades.Indices
{
    
    public class TipoCategoriaMusical : IEquatable<TipoCategoriaMusical>
    {

        public TipoCategoriaMusical()
        {
            this.Musical = CategoriaMusical.Dormir;
        }

        public TipoCategoriaMusical(CategoriaMusical categoria)
        {
            this.Musical = categoria;
        }
        
        public int ID { get; set; }
       
        public CategoriaMusical Musical {get;set;}

        public bool Equals([AllowNull] TipoCategoriaMusical other)
        {
            return  this.Musical == other.Musical;
        }
    }
}
