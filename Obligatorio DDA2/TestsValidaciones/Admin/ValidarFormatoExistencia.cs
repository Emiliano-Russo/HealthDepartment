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
        public void InicarSesion_DatosCorrectosAdmin_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            validaciones.ValidarFormatoExistencia(admin);
        }
    }
}
