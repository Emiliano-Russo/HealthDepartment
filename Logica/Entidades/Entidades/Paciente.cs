using System;

namespace Entidades
{
    public class Paciente
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }

        public string NumeroCelular { get; set; }

        public CategoriaDolencia Dolencia { get; set; }

        public float TiempoSolicitadoHoras { get; set; }

        public Paciente Clon()
        {
            Paciente paciente = new Paciente
            {
                Apellido = this.Apellido,
                Dolencia = this.Dolencia,
                Email = this.Email,
                FechaNacimiento = this.FechaNacimiento,
                Nombre = this.Nombre,
                NumeroCelular = this.NumeroCelular,
                TiempoSolicitadoHoras = this.TiempoSolicitadoHoras
            };
            return paciente;
        }
    }
}