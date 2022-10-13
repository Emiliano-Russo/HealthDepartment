using System;

namespace LogicaNegocio
{
    public class Paciente
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Email { get; set; }

        public string NumeroCelular { get; set; }

        public CategoriaDolencia Dolencia { get; set; }
    }
}