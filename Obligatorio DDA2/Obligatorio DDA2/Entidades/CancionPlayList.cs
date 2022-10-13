using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Entidades
{
    public class CancionPlayList
    {
        public Cancion Cancion { get; set; }

        public List<int> IdPlayLists { get; set; }
    }
}
