using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.Repositorio.RepositorioBDD.Entidades
{
    [Table("IX_Cancion_PlayList")]
    public class IXCancionPlayList
    {

        public IXCancionPlayList()
        {

        }

        public IXCancionPlayList(int idCancion, int idPlayList)
        {
            this.IDCancion = idCancion;
            this.IDPlayList = idPlayList;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDCancion { get; set; }

        public int IDPlayList { get; set; }
    }
}
