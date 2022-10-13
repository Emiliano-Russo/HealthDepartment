using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Entidades
{
    public class VideoPlayList
    {
        public Video Video { get; set; }

        public List<int> IdPlayLists { get; set; }
    }
}
