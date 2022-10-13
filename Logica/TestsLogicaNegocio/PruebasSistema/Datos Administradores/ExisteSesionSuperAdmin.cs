using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void ExisteSesionSuperAdmin_TokenCorrecto_SinExcepciones()
        {
            Admin superAdmin = new Admin
            {
                Email = "superAdmin@gmail.com",
                Contrasenia = "1234"
            };
            string token = sistema.IniciarSesion(superAdmin);
            Assert.IsTrue(sistema.ExisteSesionSuperAdmin(token));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionSuperAdmin_TokenNull_Excepcion()
        {
            sistema.ExisteSesionSuperAdmin(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionSuperAdmin_TokenVacio_Excepcion()
        {
            sistema.ExisteSesionSuperAdmin("");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionSuperAdmin_TokenLargo_Excepcion()
        {
            string token = Util.StringAleatorio(1000);
            sistema.ExisteSesionSuperAdmin(token);
        }
    }
}
