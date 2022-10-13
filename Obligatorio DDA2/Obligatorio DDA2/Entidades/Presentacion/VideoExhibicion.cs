using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Entidades.Presentacion
{
    public class VideoExhibicion
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public int DuracionMins { get; set; }

        public string LinkVideo { get; set; }

        public string Autor { get; set; }

        public List<string> ListaCategorias { get; set; }

    }
}
