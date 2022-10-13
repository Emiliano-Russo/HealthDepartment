using Entidades;
using Entidades.Indices;
using Interfaces;
using Interfaces.Validaciones;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Api.Entidades;

namespace LogicaNegocio.Validaciones
{
    internal class ValidacionPsicologia : IValidacionPsicologia
    {
        private IRepositorio repositorio;

        internal ValidacionPsicologia(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        //Publico
        public void ValidarPsicologoExistencia(int id)
        {
            bool psicologoExiste = repositorio.ExistePsicologo(id);
            if (!psicologoExiste)
            {
                throw new ExcepcionPsicologia("El psicologo no existe");
            }
        }

        public void ValidarFormatoPsicologo(Psicologo psicologo)
        {
            this.PsicologoEsNullExcepcion(psicologo);
            this.ValidarCamposDeTexto(psicologo);
            this.ValidarDolencias(psicologo);
        }

        public void ValidarFormatoPaciente(Paciente paciente)
        {
            ValidarPacienteNulo(paciente);
            bool entidadValida = EntidadValida(paciente);
            if (!entidadValida)
            {
                throw new ExcepcionPsicologia("Datos Paciente Invalidos");
            }
            if (paciente.Dolencia != CategoriaDolencia.Otros)
            {
                bool hayPsicologosDisponibleParaEsaDolencia = HayPsicologosDisponibleParaEsaDolencia(paciente.Dolencia);
                 if (!hayPsicologosDisponibleParaEsaDolencia)
                    throw new ExcepcionPsicologia("No existen psicologos disponibles para esa dolencia");
            }
        }

        public void ValidarDescuento(Descuento descuento)
        {
            bool mailCorrecto = !string.IsNullOrEmpty(descuento.Email);
            bool descuentoCorrecto = descuento.Porcentaje == 15
                                     || descuento.Porcentaje == 25
                                     || descuento.Porcentaje == 50;
            if (!mailCorrecto || !descuentoCorrecto)
                throw new ExcepcionPsicologia("Datos del descuento incorrectos");

            bool aptoParaDescuento = repositorio.AptoParaDescuento(descuento.Email);

            if (!aptoParaDescuento)
                throw new ExcepcionPsicologia("Este mail no es apto para un descuento");
        }

        //Privado

        private void ValidarPacienteNulo(Paciente paciente)
        {
            if (paciente == null)
                throw new ExcepcionPsicologia("Paciente null");
        }

        private bool EntidadValida(Paciente paciente)
        {
            bool camposDeTextoValidos = CamposDeTextoValidos(paciente);
            bool fechaValida = paciente.FechaNacimiento < DateTime.Now;
            bool entidadValida = camposDeTextoValidos && fechaValida;
            return entidadValida;
        }

        private void ValidarCamposDeTexto(Psicologo psicologo)
        {
            this.PsicologoConAtributosNulosExcpecion(psicologo);
            this.PsicologoConStringsVaciosExcpecion(psicologo);
            this.NombreConNumerosExcpecion(psicologo);
        }

        private void ValidarDolencias(Psicologo psicologo)
        {
            this.PsicologoSinDolenciasExcpecion(psicologo);
            this.DolenciasRepetidasExcpecion(psicologo);
            this.MasDeTresDolenciasExcpecion(psicologo);
            this.PsicologoExpertoEnDolenciaOtrosExcpecion(psicologo);
        }

        private bool CamposDeTextoValidos(Paciente paciente)
        {
            bool nombreValido = !String.IsNullOrEmpty(paciente.Nombre);
            bool apellidoValido = !String.IsNullOrEmpty(paciente.Apellido);
            bool emailValido = !String.IsNullOrEmpty(paciente.Email);
            bool numeroValido = !String.IsNullOrEmpty(paciente.NumeroCelular) && paciente.NumeroCelular.All(char.IsDigit);
            return nombreValido && apellidoValido && emailValido && numeroValido;
        }
        private bool HayPsicologosDisponibleParaEsaDolencia(CategoriaDolencia dolencia)
        {
            return repositorio.HayPsicologosDisponibleParaEsaDolencia(dolencia);
        }

        private void PsicologoEsNullExcepcion(Psicologo psicologo)
        {
            bool psicologoNull = psicologo == null;
            if (psicologoNull)
                throw new ExcepcionPsicologia("Un psicologo no puede ser nulo");
        }

        private void PsicologoConAtributosNulosExcpecion(Psicologo psicologo)
        {
            this.PsicologoConNombreNuloExcpecion(psicologo);
            this.PsicologoConDireccionNulaExcpecion(psicologo);
            this.PsicologoConDolenciasNulaExcpecion(psicologo);
        }

        private void PsicologoConNombreNuloExcpecion(Psicologo psicologo)
        {
            bool nombreNulo = psicologo.Nombre == null;
            if (nombreNulo)
                throw new ExcepcionPsicologia("Un psicologo no puede tener un nombre nulo");
        }

        private void PsicologoConDireccionNulaExcpecion(Psicologo psicologo)
        {
            bool direccionNulo = psicologo.DireccionUrbana == null;
            if (direccionNulo)
                throw new ExcepcionPsicologia("Un psicologo no puede tener una direccion nula");
        }

        private void PsicologoConDolenciasNulaExcpecion(Psicologo psicologo)
        {
            bool dolenciasNula = psicologo.DolenciasQueTrata == null;
            if (dolenciasNula)
                throw new ExcepcionPsicologia("Un psicologo no puede tener dolencias nula");
        }
        private void PsicologoSinDolenciasExcpecion(Psicologo psicologo)
        {
            bool psicologoTieneDolencias = psicologo.DolenciasQueTrata.Count == 0;
            if (psicologoTieneDolencias)
                throw new ExcepcionPsicologia("El psicologo no tiene dolencias asignadas");
        }

        private void PsicologoConStringsVaciosExcpecion(Psicologo psicologo)
        {
            this.PsicologoConNombreStringVacioExcpecion(psicologo);
            this.PsicologoConDireccionStringVacioExcepcion(psicologo);
        }

        private void PsicologoConNombreStringVacioExcpecion(Psicologo psicologo)
        {
            bool stringVacio = psicologo.Nombre == "";
            if (stringVacio)
                throw new ExcepcionPsicologia("No pueden haber psicologos sin nombre");
        }

        private void PsicologoConDireccionStringVacioExcepcion(Psicologo psicologo)
        {
            bool stringVacio = psicologo.DireccionUrbana == "";
            if (stringVacio)
                throw new ExcepcionPsicologia("No pueden haber psicologos sin direccion");
        }

        private void NombreConNumerosExcpecion(Psicologo psicologo)
        {
            string nombre = psicologo.Nombre;
            foreach (char caracter in nombre)
            {
                bool esNumero = caracter > '0' && caracter < '9';
                if (esNumero)
                    throw new ExcepcionPsicologia("No pueden haber nombres de psicologos con numeros");
            }
        }

        private void DolenciasRepetidasExcpecion(Psicologo psicologo)
        {
            List<TipoCategoriaDolencia> dolencias = (List<TipoCategoriaDolencia>)psicologo.DolenciasQueTrata;
            foreach (var dolencia in dolencias)
            {
                if (this.SeRepiteDolencia(dolencia.Dolencia, dolencias))
                    throw new ExcepcionPsicologia("Este psicologo tiene ingresada una misma dolencia dos veces");
            }
        }

        private bool SeRepiteDolencia(CategoriaDolencia dolencia, List<TipoCategoriaDolencia> dolencias)
        {
            List<TipoCategoriaDolencia> lista = dolencias.FindAll(x => x.Dolencia == dolencia);
            return lista.Count > 1;
        }

        private void MasDeTresDolenciasExcpecion(Psicologo psicologo)
        {
            if (psicologo.DolenciasQueTrata.Count > 3)
                throw new ExcepcionPsicologia("Un psicologo no puede manejar mas de tres dolencias");

        }

        private void PsicologoExpertoEnDolenciaOtrosExcpecion(Psicologo psicologo)
        {
            bool contieneDolenciaOtros = psicologo.DolenciasQueTrata.Contains(new TipoCategoriaDolencia(CategoriaDolencia.Otros));
            if (contieneDolenciaOtros)
                throw new ExcepcionPsicologia("Un psicologo no puede manejar la dolencia otros");
        }


    }
}
