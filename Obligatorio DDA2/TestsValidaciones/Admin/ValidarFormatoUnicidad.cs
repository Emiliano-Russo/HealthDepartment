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
        public void AgendarAdmin_AdminYaRegistrado_Excepcion()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            repositorio.AgregarAdmin(admin);
            validaciones.ValidarFormatoUnicidad(admin);
        }
    }
}
