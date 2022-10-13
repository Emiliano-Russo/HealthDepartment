using System.Collections.Generic;

namespace LogicaNegocio
{
    //ID es la categoriaMusical
    public class GaleriaMusical
    {
        public CategoriaMusical CategoriaMusical { get; set; } 

        public List<Playlist> PlayLists { get; set; }

        public List<Cancion> Canciones { get; set; }
    }
}