using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio.Excepciones;
using Utilidades;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void ExisteSesionAdmin_TokenCorrecto_SinExcepciones()
        {
            Admin admin = new Admin
            {
                Email = "admin@gmail.com",
                Contrasenia = "1234"
            };
            sistema.AgregarAdmin(admin);
            string token = sistema.IniciarSesion(admin);
            Assert.IsTrue(sistema.ExisteSesionAdmin(token));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionAdmin_TokenVacio_Excepcion()
        {
            string token = "";
            sistema.ExisteSesionAdmin(token);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionAdmin_TokenNull_Excepcion()
        {
            sistema.ExisteSesionAdmin(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionAdmin_TokenLargo_Excepcion()
        {

            string token = Util.StringAleatorio(1000);
            sistema.ExisteSesionAdmin(token);
            
        }
    }
}
