using Entidades;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Entidades
{
    public static class Fix
    {
        public static List<Cancion> Canciones { get; set; }
        public static List<Video> Videos { get; set; }
    }
}
