using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositorio.Repositorio.RepositorioBDD.Entidades
{
    [Table("IX_Video_PlayList")]
    public class IXVideoPlayList
    {
        public IXVideoPlayList()
        {

        }
        public IXVideoPlayList(int idVideo,int idPlayList)
        {
            this.IDPlayList = idPlayList;
            this.IDVideo = idVideo;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int IDVideo { get; set; }

        public int IDPlayList { get; set; }
    }
}
