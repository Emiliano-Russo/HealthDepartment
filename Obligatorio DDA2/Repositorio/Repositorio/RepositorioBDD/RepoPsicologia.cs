using Entidades;
using Entidades.Indices;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositorio.Logica;
using Repositorio.Repositorio.Logica.Entidades;
using Repositorio.Repositorio.RepositorioBDD.Entidades;
using Repositorio.Repositorio.RepositorioBDD.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Api.Entidades;

namespace Repositorio.Repositorio.RepositorioBDD
{
    internal class RepoPsicologia
    {
        private OperacionesCitas operacionesCitas;
        private LogicaRepoPsicologia logica;
        private DbContextOptions<EntidadesContexto> opciones;
        private const int creditosParaDescuento = 5;

        internal RepoPsicologia(DbContextOptions<EntidadesContexto> opciones)
        {
            logica = new LogicaRepoPsicologia();
            this.opciones = opciones;
        }

        internal bool ExistePsicologo(int id)
        {
            Psicologo retorno = null;
            using (var contexto = new EntidadesContexto(opciones))
            {
                retorno = contexto.Psicologos.Find(id);
            }
            return retorno != null;
        }

        internal Cita AgendarCita(Paciente paciente)
        {
            Cita cita = new Cita();
            using (var contexto = new EntidadesContexto(opciones))
            {
                List<Psicologo> listaPsicologos = logica.TraerTodosLosPsicologos(contexto);
                List<Cita> listaCitas = contexto.Citas.ToList();
                operacionesCitas = new OperacionesCitas(listaCitas, listaPsicologos);
                cita = operacionesCitas.AgendarCita(paciente);
                cita.DuracionSesionHoras = paciente.TiempoSolicitadoHoras;        
                logica.AsignarPrecioFinal(ref cita, paciente.Email,contexto);
                logica.SumarCreditos(contexto, paciente.Email);
                contexto.Citas.Add(cita);
                contexto.SaveChanges();
            }
            return cita;
        }

       

        internal List<CategoriaDolencia> GetProblematicas()
        {
            return Enum.GetValues(typeof(CategoriaDolencia)).Cast<CategoriaDolencia>().ToList();
        }

        internal bool AptoParaDescuento(string email)
        {
            bool apto = false;
            using(var contexto = new EntidadesContexto(opciones))
            {
                Credito credito = contexto.Creditos.Single(x => x.Email == email);
                if (credito != null && credito.Creditos == creditosParaDescuento) 
                    apto = true; 
            }
            return apto;
        }

        internal void BorrarTodosLosDatos()
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                contexto.Database.EnsureDeleted();
                contexto.SaveChanges();
            }
        }

        internal Psicologo GetPsicologo(int id)
        {
            Psicologo psicolgo = null;
            using (var contexto = new EntidadesContexto(opciones))
            {
                psicolgo = TraerPsicologo(id,contexto);
            }
            return psicolgo;
        }

        private Psicologo TraerPsicologo(int id, EntidadesContexto contexto)
        {
            Psicologo psicolgo = contexto.Psicologos.Find(id);
            psicolgo.DolenciasQueTrata = logica.ArmarDolenciasPsicologo(id, contexto);
            return psicolgo;
        }
       
        internal List<Psicologo> GetTodosLosPsicologos()
        {
            List<Psicologo> listaPsicologo = new List<Psicologo>();
            using (var contexto = new EntidadesContexto(opciones))
            {
                listaPsicologo = logica.TraerTodosLosPsicologos(contexto);
            }
            return listaPsicologo;
        }
       
        internal bool HayPsicologosDisponibleParaEsaDolencia(CategoriaDolencia dolencia)
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                List<IXPsicologoDolencia> lista = contexto.IndicePsicologoDolencia.ToList();
                foreach (IXPsicologoDolencia indice in lista)
                {
                    if (indice.IDDolencia == dolencia)
                        return true;
                }
            }
            return false;
        }

        internal int AltaPsicologo(Psicologo psicologo)
        {
            int id = 0;
            psicologo = psicologo.Clonar();
            psicologo.ID = 0;
            using (var contexto = new EntidadesContexto(opciones))
            {
                contexto.Psicologos.Add(psicologo);
                contexto.SaveChanges();
                id = psicologo.ID;
                logica.SituarDolenciasEnIndices(psicologo, contexto);
                contexto.SaveChanges();
            }
            return id;
        }

        internal void ModificarPsicologo(int id, Psicologo psicologo)
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                psicologo.ID = id;
                contexto.Psicologos.Update(psicologo);
                logica.RemoverTodasLasDolencias(id, contexto);
                logica.SituarDolenciasEnIndices(psicologo, contexto);
                contexto.SaveChanges();
            }
        }

        internal void BajaPsicologo(int id)
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                Psicologo psicologo = new Psicologo();
                psicologo.ID = id;
                contexto.Psicologos.Remove(psicologo);
                logica.RemoverTodasLasDolencias(id, contexto);
                contexto.SaveChanges();
            }
        }

        internal void GuardarDescuento(Descuento descuento)
        {
            using(var contexto = new EntidadesContexto(opciones))
            {
                contexto.Descuentos.Add(descuento);
                string emailDescuento = descuento.Email;
                Credito credito = contexto.Creditos.Single(x => x.Email == emailDescuento);
                credito.Creditos -= creditosParaDescuento;
                contexto.Creditos.Update(credito);
                contexto.SaveChanges();
            }
        }

        internal List<string> TraerMailsAptosParaDescuento()
        {
            List<string> listaMails = new List<string>();
            using (var contexto = new EntidadesContexto(opciones))
            {
                List<Credito> listaCreditos = contexto.Creditos.ToList();
                foreach (Credito credito in listaCreditos)
                {
                    string email = credito.Email;
                    int creditos = credito.Creditos;
                    if (creditos >= 5)
                        listaMails.Add(email);
                }
            }
            return listaMails;
        }
     
    }
}
