using Interfaces.Validaciones;
using LogicaNegocio.Validaciones.Implementaciones;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Repositorio.RepositorioBDD;
using Entidades;
using LogicaNegocio.Excepciones;

namespace TestsValidaciones
{
    public partial class Validacion
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void AgendarAdmin_AdminEmailVacio_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = "",
                Contrasenia = "1234"
            };
            validaciones.ValidarFormato(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void AgendarAdmin_AdminEmailNull_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = null,
                Contrasenia = "1234"
            };
            validaciones.ValidarFormato(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void AgendarAdmin_AdminContraVacia_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = ""
            };
            validaciones.ValidarFormato(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void AgendarAdmin_AdminContraNull_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = null
            };
            validaciones.ValidarFormato(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void AgendarAdmin_TodoNull_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = null,
                Contrasenia = null
            };
            validaciones.ValidarFormato(admin);
        }
    }
}
