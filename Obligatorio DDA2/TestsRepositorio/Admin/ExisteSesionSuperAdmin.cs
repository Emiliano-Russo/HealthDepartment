using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {

        [TestMethod]
        public void ExisteSesionSuperAdmin_TokenCorrecto_SinExcepciones()
        {
            Admin superAdmin = new Admin
            {
                Email = "superAdmin@gmail.com",
                Contrasenia = "1234",
                EsSuperAdmin = true
            };
            repositorio.AgregarAdmin(superAdmin);
            string token = repositorio.IniciarSesion(superAdmin);
            Assert.IsTrue(repositorio.ExisteSesionSuperAdmin(token));
        }
    }
}
