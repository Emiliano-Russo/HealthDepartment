using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {

        [TestMethod]
        public void AgendarAdmin_DatosCorrectos_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            repositorio.AgregarAdmin(admin);
        }

        [TestMethod]
        public void AgendarAdmin_AdminsDiferentesDatos_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            repositorio.AgregarAdmin(admin);
            admin.Email = "german@gmail.com";
            repositorio.AgregarAdmin(admin);
        }
    }
}
