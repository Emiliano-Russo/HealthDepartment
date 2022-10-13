using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void AgendarAdmin_DatosCorrectos_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
        }

        [TestMethod]
        public void AgendarAdmin_AdminsDiferentesDatos_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
            admin.Email = "german@gmail.com";
            sistema.AgregarAdmin(admin);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void AgendarAdmin_AdminEmailVacio_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = "",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
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
            sistema.AgregarAdmin(admin);
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
            sistema.AgregarAdmin(admin);
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
            sistema.AgregarAdmin(admin);
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
            sistema.AgregarAdmin(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void AgendarAdmin_AdminYaRegistrado_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
            sistema.AgregarAdmin(admin);
        }
    }
}
