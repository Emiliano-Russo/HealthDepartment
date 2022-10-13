using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.Repositorio.RepositorioBDD.Entidades
{
    [Table("IX_Video_Galeria")]
    public class IXVideoGaleria
    {
        public IXVideoGaleria()
        {

        }
        public IXVideoGaleria(int idVideo, CategoriaMusical idGaleria)
        {
            this.IDVideo = idVideo;
            this.IDGaleria = idGaleria;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDVideo { get; set; }

        public CategoriaMusical IDGaleria { get; set; }
    }
}
