using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Entidades.Presentacion
{
    public class GaleriaMusicalExhibicion
    {

        public string CategoriaMusical { get; set; }

        public List<PlaylistExhibicion> PlayLists { get; set; }

        public List<CancionExhibicion> Canciones { get; set; }

        public List<VideoExhibicion> Videos { get; set; }
    }
}
