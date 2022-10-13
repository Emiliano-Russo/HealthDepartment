using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {

        [TestMethod]
        public void ExisteSesionAdmin_TokenCorrecto_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            repositorio.AgregarAdmin(admin);
            string token = repositorio.IniciarSesion(admin);
            Assert.IsTrue(repositorio.ExisteSesionAdmin(token));
        }
    }
}
