using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Cita")]
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int IdPsicologo { get;set; }

        public string NombrePsicologo { get; set; }

        public FormatoConsulta FormatoConsulta { get; set; }

        public string DireccionConsulta { get; set; }

        public DateTime FechaConsulta { get; set; }

        public float PrecioFinal { get; set; }

        public float Descuento { get; set; }

        public float DuracionSesionHoras { get; set; }

        public bool EsVacia()
        {
            return String.IsNullOrEmpty(NombrePsicologo) || String.IsNullOrEmpty(DireccionConsulta);
        }
    }
}