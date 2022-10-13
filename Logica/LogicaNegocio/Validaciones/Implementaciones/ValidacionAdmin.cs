using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Interfaces.Validaciones;
using Interfaces;

namespace LogicaNegocio.Validaciones
{
    internal class ValidacionAdmin : IValidacionAdmin
    {
        private IRepositorio repositorio;
        internal ValidacionAdmin(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void ValidarFormato(Admin admin)
        {
            if (admin == null)
                throw new ExcepcionDatosAdmin("Admin null");
            bool emailCorrecto = !String.IsNullOrEmpty(admin.Email);
            bool contraseniaCorrecta = !String.IsNullOrEmpty(admin.Contrasenia);
            bool formatoAdminValido = emailCorrecto && contraseniaCorrecta;
            if (!formatoAdminValido)
                throw new ExcepcionDatosAdmin("Datos Admin Incorrectos");
        }

        public void ValidarFormatoExistencia(Admin admin)
        {
            this.ValidarFormato(admin);
            bool existe = repositorio.ExisteAdmin(admin);
            if (!existe)
                throw new ExcepcionDatosAdmin("Admin no registrado");
        }

        public void ValidarFormatoToken(string token)
        {
            if (String.IsNullOrEmpty(token) || token.Length > 512)
                throw new ExcepcionDatosAdmin("Token invalido");
        }

        public void ValidarFormatoUnicidad(Admin admin)
        {
            ValidarFormato(admin);
            ValidarUnicidadAdmin(admin);
        }


        //Privado

        private void ValidarUnicidadAdmin(Admin admin)
        {
            bool existe = repositorio.ExisteAdmin(admin);
            if (existe)
                throw new ExcepcionDatosAdmin("El admin ya existe");
        }


    }
}
