using System;

namespace LogicaNegocio
{

    //Las citas se identifican con un ID
    public class Cita
    {
        public int IdPsicologo { get;set; }

        public string NombrePsicologo { get; set; }

        public FormatoConsulta FormatoConsulta { get; set; }

        public string DireccionConsulta { get; set; }

        public DateTime FechaConsulta { get; set; }

        internal bool EsVacia()
        {
            return String.IsNullOrEmpty(NombrePsicologo) || String.IsNullOrEmpty(DireccionConsulta);
        }
    }
}