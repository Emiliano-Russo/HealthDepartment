using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Entidades.Indices
{
    
    public class TipoCategoriaDolencia: IEquatable<TipoCategoriaDolencia>
    {
        public TipoCategoriaDolencia()
        {

        }
        public TipoCategoriaDolencia(CategoriaDolencia categoria)
        {
            this.Dolencia = categoria;
        }

        
        public int ID { get; set; }
        
        public CategoriaDolencia Dolencia { get; set; }

        public bool Equals([AllowNull] TipoCategoriaDolencia other)
        {
            return this.Dolencia == other.Dolencia;
        }
    }
}
