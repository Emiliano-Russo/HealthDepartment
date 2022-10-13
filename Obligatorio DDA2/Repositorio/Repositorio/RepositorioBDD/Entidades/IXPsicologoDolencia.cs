using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.Repositorio.RepositorioBDD.Entidades
{
    [Table("IX_Psicologo_Dolencia")]
    internal class IXPsicologoDolencia
    {

        public IXPsicologoDolencia()
        {

        }

        public IXPsicologoDolencia(int idPsicologo, CategoriaDolencia idDolencia)
        {
            this.IDPsicologo = idPsicologo;
            this.IDDolencia = idDolencia;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDPsicologo { get; set; }

        public CategoriaDolencia IDDolencia { get; set; }
    }
}
