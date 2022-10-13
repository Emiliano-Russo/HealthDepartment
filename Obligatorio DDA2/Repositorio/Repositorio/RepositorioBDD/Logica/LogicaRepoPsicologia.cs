using Entidades;
using Entidades.Indices;
using Repositorio.Repositorio.Logica.Entidades;
using Repositorio.Repositorio.RepositorioBDD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Api.Entidades;

namespace Repositorio.Repositorio.RepositorioBDD.Logica
{
    internal class LogicaRepoPsicologia
    {
        internal IReadOnlyCollection<TipoCategoriaDolencia> ArmarDolenciasPsicologo(int id, EntidadesContexto contexto)
        {
            List<TipoCategoriaDolencia> listaDolencias = new List<TipoCategoriaDolencia>();
            List<IXPsicologoDolencia> listaDolenciasPsicologo = contexto
                                                .IndicePsicologoDolencia.Where(indice => indice.IDPsicologo == id).ToList();
            foreach (IXPsicologoDolencia indice in listaDolenciasPsicologo)
            {
                TipoCategoriaDolencia tipoCategoriaDolencia = new TipoCategoriaDolencia(indice.IDDolencia);
                listaDolencias.Add(tipoCategoriaDolencia);
            }
            return listaDolencias;
        }

        internal List<Psicologo> TraerTodosLosPsicologos(EntidadesContexto contexto)
        {
            List<Psicologo> listaPsicologos = contexto.Psicologos.ToList();
            foreach (Psicologo psicologo in listaPsicologos)            
                psicologo.DolenciasQueTrata = ArmarDolenciasPsicologo(psicologo.ID, contexto);
            
            return listaPsicologos;
        }

        internal void SituarDolenciasEnIndices(Psicologo psicologo, EntidadesContexto contexto)
        {
            foreach (TipoCategoriaDolencia tipoDolencia in psicologo.DolenciasQueTrata)
            {
                IXPsicologoDolencia indice = new IXPsicologoDolencia(psicologo.ID, tipoDolencia.Dolencia);
                contexto.IndicePsicologoDolencia.Add(indice);
            }
        }

        internal void RemoverTodasLasDolencias(int idPsicologo, EntidadesContexto contexto)
        {
            var query = contexto.IndicePsicologoDolencia.AsQueryable();
            query = query.Where(x => x.IDPsicologo == idPsicologo);
            contexto.IndicePsicologoDolencia.RemoveRange(query);
            contexto.SaveChanges();
        }

        internal void AsignarPrecioFinal(ref Cita cita, string email, EntidadesContexto contexto)
        {
            InicializarEmailEnDescuentos(email, contexto);
            List<Descuento> descuentos = contexto.Descuentos.ToList();
            bool hayDescuentoParEmail = descuentos.Exists(x => x.Email == email);
            if (hayDescuentoParEmail)
                AplicarPrecioConDescuento(ref cita, email, contexto);
            else
                AplicarPrecioSinDescuento(ref cita, contexto);
        }
        private void AplicarPrecioConDescuento(ref Cita cita, string email, EntidadesContexto contexto)
        {
            int idPsicologo = cita.IdPsicologo;
            Psicologo psicologo = contexto.Psicologos.Find(cita.IdPsicologo);

            Descuento descuento = contexto.Descuentos.Single(x => x.Email == email);
            float porcentajeDescuento = (1 - ((float)descuento.Porcentaje / 100));
            float precioFinal = cita.DuracionSesionHoras
                * psicologo.PrecioHora
                * porcentajeDescuento;

            cita.PrecioFinal = precioFinal;
            cita.Descuento = descuento.Porcentaje;
            contexto.Descuentos.Remove(descuento);
            Credito credito = contexto.Creditos.Single(x => x.Email == email);
            credito.Creditos -= 5;
            contexto.Update(credito);
            contexto.SaveChanges();
        }

        private void AplicarPrecioSinDescuento(ref Cita cita, EntidadesContexto contexto)
        {
            Psicologo psicologo = contexto.Psicologos.Find(cita.IdPsicologo);
            float precioFinal = cita.DuracionSesionHoras * psicologo.PrecioHora;
            cita.PrecioFinal = precioFinal;
            cita.Descuento = 0; // el descuento es 0%
        }


        private void InicializarEmailEnDescuentos(string email, EntidadesContexto contexto)
        {
            List<Credito> listaCredito = contexto.Creditos.ToList();
            bool EmailRegistradoEnCreditos = listaCredito.Exists(c => c.Email == email);
            if (!EmailRegistradoEnCreditos)
            {
                Credito credito = new Credito
                {
                    Email = email,
                    Creditos = 0
                };
                contexto.Creditos.Add(credito);
                contexto.SaveChanges();
            }
        }

        internal void SumarCreditos(EntidadesContexto contexto, string email)
        {
            Credito credito = contexto.Creditos.Single(x => x.Email == email);
            if (credito.Creditos < 5)
            {
                credito.Creditos++;
                contexto.Creditos.Update(credito);
                contexto.SaveChanges();
            }
        }

    }
}
