using Entidades;
using Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Indices;
using Repositorio.Repositorio.Logica.Entidades;
using Web.Api.Entidades;

namespace Repositorio.Repositorio.Logica
{
    internal class OperacionesCitas
    {
        private List<Cita> listaCitas;
        private List<Psicologo> listaPsicologo;

        internal OperacionesCitas(List<Cita> listaCitas, List<Psicologo> listaPsicologo)
        {
            this.listaCitas = listaCitas;
            this.listaPsicologo = listaPsicologo;
        }

        internal Cita AgendarCita(Paciente paciente)
        {
            DateTime fecha = DateTime.Now;
            return AgendarCita(paciente, fecha);
        }

        private Cita AgendarCita(Paciente paciente, DateTime diaDeSolicitud)
        {         
            Cita cita = BuscarCitaDisponibleEnSemana(paciente, diaDeSolicitud);
            if (cita.EsVacia())
            {
                diaDeSolicitud = SaltarAlProximoLunes(diaDeSolicitud);
                return AgendarCita(paciente, diaDeSolicitud);
            }
            else
                return cita;
        }

        private Cita BuscarCitaDisponibleEnSemana(Paciente paciente, DateTime diaDeSolicitud)
        {
            for (int i = 0; i < listaPsicologo.Count; i++)
            {
                bool trataDolencia = TrataDolencia(listaPsicologo[i].ID, paciente.Dolencia);

                if (trataDolencia)
                {
                    Cita cita = IntenarArmarCitaEstaSemana(listaPsicologo[i].ID, diaDeSolicitud);
                    if (!cita.EsVacia())
                        return cita;
                }
            }
            return new Cita();
        }

        private bool TrataDolencia(int idPsicologo, CategoriaDolencia dolencia)
        {
            Psicologo psicologo = listaPsicologo.Find(x => x.ID == idPsicologo);
            return psicologo.DolenciasQueTrata.Any(x => x.Dolencia == dolencia)
                    || dolencia == CategoriaDolencia.Otros;
        }

        private Cita IntenarArmarCitaEstaSemana(int idPsicologo, DateTime diaDeSolicitud)
        {
            Cita cita = new Cita();
            bool tieneLugar = QuedaLugarEstaSemana(diaDeSolicitud, idPsicologo);
            if (tieneLugar)
            {
                cita = ReservarCita(idPsicologo, diaDeSolicitud);
            }
            return cita;
        }

        private Cita ReservarCita(int idPsicologo, DateTime diaDeSolicitud)
        {
            Cita cita = new Cita();
            DateTime diaDisponible = GetDiaDisponible(diaDeSolicitud, idPsicologo);
            cita = ArmarCita(diaDisponible, idPsicologo);
            listaCitas.Add(cita);
            return cita;
        }

        private DateTime GetDiaDisponible(DateTime semanaSolicitud, int indexPsicologo)
        {
            List<Cita> listaCitasSemana = GetCitasRegistradas(indexPsicologo, semanaSolicitud);
            return GetDiaDisponibleEnSemana(semanaSolicitud, listaCitasSemana);
        }

        private DateTime GetDiaDisponibleEnSemana(DateTime diaDeSolicitud, List<Cita> listaCitasEsaSemana)
        {
            for (int dia = (int)diaDeSolicitud.DayOfWeek; dia <= (int)DayOfWeek.Friday; dia++)
            {
                bool existeLugarParaDia = ExisteLugarElDia((DayOfWeek)dia, listaCitasEsaSemana);

                if (existeLugarParaDia)
                {
                    int diferencia = dia - (int)diaDeSolicitud.DayOfWeek;
                    DateTime fechaRetorno = diaDeSolicitud.AddDays(diferencia);
                    return fechaRetorno;
                }
            }
            throw new Exception();
        }

        private DateTime SaltarAlProximoLunes(DateTime diaDeSolicitud)
        {
            if (diaDeSolicitud.DayOfWeek == DayOfWeek.Sunday)
                return diaDeSolicitud.AddDays(1);
            int diferencia = (DayOfWeek.Saturday - diaDeSolicitud.DayOfWeek) + 2;
            return diaDeSolicitud.AddDays(diferencia);
        }

        private Cita ArmarCita(DateTime dia, int idPsicologo)
        {
            Psicologo psicologo = listaPsicologo.Find(x => x.ID == idPsicologo);
            Cita cita = new Cita
            {
                IdPsicologo = idPsicologo,
                DireccionConsulta = DireccionEnBaseAlFormatoDelPsicologo(psicologo, idPsicologo),
                FechaConsulta = dia,
                FormatoConsulta = psicologo.FormatoConsulta,
                NombrePsicologo = psicologo.Nombre
            };
            return cita;
        }

        private bool QuedaLugarEstaSemana(DateTime diaDeSolicitud, int indexPsicologo)
        {
            if (EsFinDeSemana(diaDeSolicitud.DayOfWeek))
                return false;
            List<Cita> listaCitasSemana = GetCitasRegistradas(indexPsicologo, diaDeSolicitud);
            return ExisteLugar(listaCitasSemana, diaDeSolicitud.DayOfWeek);
        }

        private bool ExisteLugar(List<Cita> listaCitasSemana, DayOfWeek inicioDia)
        {
            bool existeLugar = false;
            for (int dia = (int)inicioDia; dia <= (int)DayOfWeek.Friday; dia++)
                existeLugar = existeLugar || ExisteLugarElDia((DayOfWeek)dia, listaCitasSemana);
            return existeLugar;
        }

        private bool EsFinDeSemana(DayOfWeek dia)
        {
            if (dia == DayOfWeek.Saturday || dia == DayOfWeek.Sunday)
                return true;
            else
                return false;
        }

        private List<Cita> GetCitasRegistradas(int indexPsicologo, DateTime semanaSolicitud)
        {
            DayOfWeek diaDeLaSemana = semanaSolicitud.DayOfWeek;
            List<Cita> citasRegistradas = listaCitas.FindAll(cita => cita.IdPsicologo == indexPsicologo);
            citasRegistradas = citasRegistradas.Where(cita => Util.FechasEnMismaSemanaEmpezandoElSabado(semanaSolicitud, cita.FechaConsulta)).ToList();
            citasRegistradas = citasRegistradas.Where(cita => diaDeLaSemana <= cita.FechaConsulta.DayOfWeek).ToList();
            return citasRegistradas;
        }


        private bool ExisteLugarElDia(DayOfWeek dia, List<Cita> listaSemanal)
        {
            return listaSemanal.FindAll(cita => cita.FechaConsulta.DayOfWeek == dia).Count < 5;
        }

        private string DireccionEnBaseAlFormatoDelPsicologo(Psicologo psicologo, int idPsicolgo)
        {
            string direccion = psicologo.DireccionUrbana;
            bool formatoVirtual = psicologo.FormatoConsulta == FormatoConsulta.Virtual;
            if (formatoVirtual)
            {
                direccion = "https://bettercalm.com.uy/" + idPsicolgo + "/" + Util.StringAleatorio(5);
            }
            return direccion;
        }
       
    }
}
