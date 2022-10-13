using Entidades.Indices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entidades
{
    [Table("Psicologo")]
    public class Psicologo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public FormatoConsulta FormatoConsulta { get; set; }

        public string DireccionUrbana { get; set; }

        public float PrecioHora { get; set; }

        [NotMapped]
        public IReadOnlyCollection<TipoCategoriaDolencia> DolenciasQueTrata { get; set; }

        public void AgregarDolencia(CategoriaDolencia dolencia)
        {
            List<TipoCategoriaDolencia> listaDolencias = (List<TipoCategoriaDolencia>)DolenciasQueTrata;
            TipoCategoriaDolencia tipo = new TipoCategoriaDolencia(dolencia); 
            if (!listaDolencias.Contains(tipo))           
                listaDolencias.Add(tipo);
            this.DolenciasQueTrata = listaDolencias;
        }

        public void SustituirListaDolencias(List<CategoriaDolencia> dolencias)
        {
            List<TipoCategoriaDolencia> listaDolencias = new List<TipoCategoriaDolencia>();
            foreach (CategoriaDolencia dolencia in dolencias)
            {
                TipoCategoriaDolencia tipo = new TipoCategoriaDolencia(dolencia);
                listaDolencias.Add(tipo);
            }
            this.DolenciasQueTrata = listaDolencias;
        }      

        public Psicologo Clonar()
        {
            Psicologo psicologoAlta = new Psicologo
            {
                DireccionUrbana = this.DireccionUrbana,
                Nombre = this.Nombre,
                FormatoConsulta = this.FormatoConsulta,
                DolenciasQueTrata = this.DolenciasQueTrata,
                ID = this.ID,
                PrecioHora = this.PrecioHora
            };
            return psicologoAlta;
        }
    }
}