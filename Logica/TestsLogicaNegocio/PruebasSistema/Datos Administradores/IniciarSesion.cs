using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void InicarSesion_DatosCorrectosAdmin_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
            sistema.IniciarSesion(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void InicarSesion_EmailVacio_Expecion()
        {
            Admin admin = new Admin
            {
                Email = "",
                Contrasenia = "1234"
            };
            sistema.IniciarSesion(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void InicarSesion_ContraseniaVacia_Expecion()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = ""
            };
            sistema.IniciarSesion(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void InicarSesion_EmailNull_Expecion()
        {
            Admin admin = new Admin
            {
                Email = null,
                Contrasenia = ""
            };
            sistema.IniciarSesion(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void InicarSesion_ContraseniaNull_Expecion()
        {
            Admin admin = new Admin
            {
                Email = "",
                Contrasenia = null
            };
            sistema.IniciarSesion(admin);
        }

        [TestMethod]
        public void InicarSesion_Admin_TokenNoEsNulo()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
            string token = sistema.IniciarSesion(admin);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void InicarSesion_Admin_TokenNoVacio()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
            string token = sistema.IniciarSesion(admin);
            bool esVacio = token == "";
            Assert.IsFalse(esVacio);
        }

        [TestMethod]
        public void InicarSesion_Admin_TokenLargoCorrecto()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
            string token = sistema.IniciarSesion(admin);
            bool largoCorrecto = token.Length <= 512 && token.Length > 0;
            Assert.IsTrue(largoCorrecto);

        }
    }
}
