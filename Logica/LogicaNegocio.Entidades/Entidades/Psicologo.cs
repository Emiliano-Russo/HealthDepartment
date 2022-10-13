using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LogicaNegocio
{
    public class Psicologo
    {
        public string Nombre { get; set; }

        public FormatoConsulta FormatoConsulta { get; set; }

        public string DireccionUrbana { get; set; }

        public List<CategoriaDolencia> DolenciasQueTrata { get; set; }

        //Refactoreo
        public Psicologo Clonar()
        {
            Psicologo psicologoAlta = new Psicologo
            {
                DireccionUrbana = this.DireccionUrbana,
                Nombre = this.Nombre,
                FormatoConsulta = this.FormatoConsulta,
                DolenciasQueTrata = this.DolenciasQueTrata
            };
            return psicologoAlta;
        }
    }
}