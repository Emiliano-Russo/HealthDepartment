using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Entidades.Presentacion
{
    public class CancionExhibicion
    {
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Duracion { get; set; }

        public string Autor { get; set; }

        public string LinkAudio { get; set; }

        public string LinkImagen { get; set; }

        public List<string> CategoriasMusicales { get; set; }
    }
}
