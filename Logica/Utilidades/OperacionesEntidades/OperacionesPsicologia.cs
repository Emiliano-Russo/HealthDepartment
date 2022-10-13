using Entidades;
using Interfaces;
using Utilidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Indices;

namespace Utilidades.OperacionesEntidades
{
    public class OperacionesPsicologia
    {
        private IRepositorio repositorio;

        public OperacionesPsicologia(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Psicologo GetPsicologoTrataEstresRegistrado()
        {
            Psicologo psicologo = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            repositorio.AltaPsicologo(psicologo);
            return psicologo; 
        }

        public bool MismosAtributos(Cita citaX, Cita citaZ)
        {
            if (citaX == null && citaZ == null)
                return true;
            bool mismaDireccionConsulta = citaX.DireccionConsulta == citaZ.DireccionConsulta;
            bool mismaFecha = citaX.FechaConsulta == citaZ.FechaConsulta;
            bool mismoFormatoConsulta = citaX.FormatoConsulta == citaZ.FormatoConsulta;
            bool mismoIdPsicologo = citaX.IdPsicologo == citaZ.IdPsicologo;
            bool mismoNombrePsicologo = citaX.NombrePsicologo == citaZ.NombrePsicologo;
            return mismaDireccionConsulta && mismaFecha
                && mismoFormatoConsulta && mismoIdPsicologo
                && mismoNombrePsicologo;
        }

        public void RegistrarCitaPacienteVeces(Paciente paciente,int veces)
        {
            for (int i = 0; i < veces; i++)
            {
                repositorio.AgendarCita(paciente);
            }
        }

        public void RegistrarPsicologoEstresEn()
        {        
            Psicologo psicologoTrataEstres = DatosGlobalesPsicologia.GetPsicologoTrataEstres();
            AltaPsicologo(psicologoTrataEstres);
        }

        public bool MismosAtributos(Psicologo ref1, Psicologo ref2)
        {
            bool iguales = true;
            iguales = iguales && ref1.DireccionUrbana == ref2.DireccionUrbana;
            List<CategoriaDolencia> listaX = Transformar(((List<TipoCategoriaDolencia>)ref1.DolenciasQueTrata));
            List<CategoriaDolencia> listaZ = Transformar(((List<TipoCategoriaDolencia>)ref2.DolenciasQueTrata));
            iguales = iguales && SonIguales(listaX,listaZ);
            iguales = iguales && ref1.FormatoConsulta == ref2.FormatoConsulta;
            iguales = iguales && ref1.Nombre == ref2.Nombre;

            return iguales;
        }

        public bool SonIguales(List<CategoriaDolencia> listaX, List<CategoriaDolencia> listaZ)
        {
            if (listaX == null && listaZ == null)
                return true;
            if (listaX.Count != listaZ.Count)
                return false;

            bool iguales = true;
            foreach (CategoriaDolencia cat in listaX)         
                iguales = iguales && listaZ.Contains(cat);
            
            return iguales;
        }

        public bool SonIguales(IReadOnlyCollection<TipoCategoriaDolencia> listaX, IReadOnlyCollection<TipoCategoriaDolencia> listaZ)
        {
            return SonIguales(Transformar((List<TipoCategoriaDolencia>)listaX), Transformar((List<TipoCategoriaDolencia>)listaZ));
        }

        public List<CategoriaDolencia> Transformar(List<TipoCategoriaDolencia> lista)
        {
            List<CategoriaDolencia> listaRetorno = new List<CategoriaDolencia>();
            foreach (TipoCategoriaDolencia tipo in lista)            
                listaRetorno.Add(tipo.Dolencia);
            
            return listaRetorno;
        }

        public int AltaPsicologo(Psicologo psicologo)
        {
            return repositorio.AltaPsicologo(psicologo);
        }

        public void AssertionDeBajaPsicologo(int id)
        {
            repositorio.GetPsicologo(id);
            repositorio.BajaPsicologo(id);
            try
            {
                repositorio.GetPsicologo(id);
                Assert.Fail("GetPsicologo retorno un valor que no se esperaba");
            }
            catch (Exception e)
            {

            }
        }

        public bool MismaLista(List<Psicologo> esperado, List<Psicologo> resultado)
        {
            if (esperado == null && resultado == null)
                return true;
            if (esperado.Count != resultado.Count)
                return false;
            bool listasIguales = true;
            for (int i = 0; i < esperado.Count; i++)
            {
                listasIguales = listasIguales && MismosAtributos(esperado[i], resultado[i]);
            }
            return listasIguales;
        }

        public void LLenarLaSemanaDeAgendaCitaPorEstresParaUnPsicologo()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    AgendarCitaEstresCantidadVeces(20);
                    break;
                case DayOfWeek.Wednesday:
                    AgendarCitaEstresCantidadVeces(15);
                    break;
                case DayOfWeek.Thursday:
                    AgendarCitaEstresCantidadVeces(10);
                    break;
                case DayOfWeek.Friday:
                    AgendarCitaEstresCantidadVeces(5);
                    break;
                default: // Lunes, Sabado, Domingo
                    AgendarCitaEstresCantidadVeces(25);
                    break;
            }
        }

        public void DejarUnLugarEnSemanaDeAgendaCitaPorEstresParaUnPsicologo()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    AgendarCitaEstresCantidadVeces(19);
                    break;
                case DayOfWeek.Wednesday:
                    AgendarCitaEstresCantidadVeces(14);
                    break;
                case DayOfWeek.Thursday:
                    AgendarCitaEstresCantidadVeces(9);
                    break;
                case DayOfWeek.Friday:
                    AgendarCitaEstresCantidadVeces(4);
                    break;
                default: // Lunes, Sabado, Domingo
                    AgendarCitaEstresCantidadVeces(24);
                    break;
            }
        }

        public void AgendarCitaEstresCantidadVeces(int veces)
        {
            for (int i = 0; i < veces; i++)
            {
                Paciente paciente = DatosGlobalesPsicologia.GetPacienteDolenciaEstres();
                repositorio.AgendarCita(paciente);
            }
        }

    }
}
