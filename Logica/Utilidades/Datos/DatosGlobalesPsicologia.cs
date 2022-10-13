using Entidades;
using Entidades.Indices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilidades
{
    public class DatosGlobalesPsicologia
    {

        public static Psicologo GetPsicologoEstandar()
        {
            List<TipoCategoriaDolencia> listaDolencias = new List<TipoCategoriaDolencia>();
            listaDolencias.Add(new TipoCategoriaDolencia(CategoriaDolencia.Enojo));
            listaDolencias.Add(new TipoCategoriaDolencia(CategoriaDolencia.Estres));
            listaDolencias.Add(new TipoCategoriaDolencia(CategoriaDolencia.Ansiedad));
            Psicologo psicologo = new Psicologo
            {
                DireccionUrbana = "Agraciada 1741",
                Nombre = "Juan Rodriguez",
                FormatoConsulta = FormatoConsulta.Presencial,
                DolenciasQueTrata = listaDolencias,
                PrecioHora = 1000
            };
            return psicologo;
        }

        public static Psicologo GetPsicologoTrataEstres()
        {
            Psicologo psicologo = GetPsicologoEstandar();
            psicologo.DolenciasQueTrata = new List<TipoCategoriaDolencia>();
            psicologo.AgregarDolencia(CategoriaDolencia.Estres);
            return psicologo;
        }

        public static Psicologo GetPsicologoTrataRelaciones()
        {
            Psicologo psicologo = GetPsicologoEstandar();
            psicologo.DolenciasQueTrata = new List<TipoCategoriaDolencia>();
            psicologo.AgregarDolencia(CategoriaDolencia.Relaciones);
            return psicologo;
        }

        public static Paciente GetPacienteDolenciaEstres()
        {
            Paciente paciente = new Paciente
            {
                Nombre = "Hector",
                Apellido = "Suarez",
                Dolencia = CategoriaDolencia.Estres,
                Email = "hector@gmail.com",
                FechaNacimiento = new DateTime(1990, 10, 25),
                NumeroCelular = "092777444",
                TiempoSolicitadoHoras = 1
            };

            return paciente;
        }

    }
}
