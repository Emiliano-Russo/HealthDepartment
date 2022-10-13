using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.Repositorio.RepositorioBDD.Entidades
{
    [Table("IX_Cancion_Galeria")]
    public class IXCancionGaleria
    {
       
        public IXCancionGaleria()
        {

        }

        public IXCancionGaleria(int idCancion,CategoriaMusical idGaleria)
        {
            this.IDCancion = idCancion;
            this.IDGaleria = idGaleria;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDCancion { get; set; }

        public CategoriaMusical IDGaleria { get; set; }
    }
}
