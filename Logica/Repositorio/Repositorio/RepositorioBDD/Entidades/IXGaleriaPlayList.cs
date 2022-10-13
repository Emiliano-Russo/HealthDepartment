using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.Repositorio.RepositorioBDD.Entidades
{
    [Table("IX_Galeria_PlayList")]
    public class IXGaleriaPlayList
    {

        public IXGaleriaPlayList()
        {

        }

        public IXGaleriaPlayList(int idPlayList, CategoriaMusical idGaleria)
        {
            this.IDPlaylist = idPlayList;
            this.IDGaleria = idGaleria;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDPlaylist { get; set; }

        public CategoriaMusical IDGaleria { get; set; }
    }
}
