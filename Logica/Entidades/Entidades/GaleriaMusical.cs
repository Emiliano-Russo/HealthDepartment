using Entidades.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("GaleriaMusical")]
    public class GaleriaMusical
    {
        [Key]
        public CategoriaMusical CategoriaMusical { get; set; } 

        [NotMapped]
        public List<Playlist> PlayLists { get; set; }

        [NotMapped]
        public List<Cancion> Canciones { get; set; }

        [NotMapped]
        public List<Video> Videos { get; set; }
    }
}