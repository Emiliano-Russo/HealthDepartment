using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Entidades.Presentacion
{
    public class PlaylistExhibicion
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string LinkImagen { get; set; }

        public List<CancionExhibicion> Canciones { get; set; }

        public List<VideoExhibicion> Videos { get; set; }

        public List<string> ListaCategorias { get; set; }

    }
}
