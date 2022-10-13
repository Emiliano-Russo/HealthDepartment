using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestsRepositorio
{
    public partial class Repositorio
    {

        [TestMethod]
        public void InicarSesion_DatosCorrectosAdmin_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            repositorio.AgregarAdmin(admin);
            repositorio.IniciarSesion(admin);
        }

        [TestMethod]
        public void InicarSesion_Admin_TokenLargoCorrecto()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            repositorio.AgregarAdmin(admin);
            string token = repositorio.IniciarSesion(admin);
            bool largoCorrecto = token.Length <= 512 && token.Length > 0;
            Assert.IsTrue(largoCorrecto);
        }
    }
}
