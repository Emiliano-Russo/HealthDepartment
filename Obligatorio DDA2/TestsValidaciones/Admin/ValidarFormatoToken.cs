using Interfaces.Validaciones;
using LogicaNegocio.Validaciones.Implementaciones;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Repositorio.RepositorioBDD;
using Entidades;
using LogicaNegocio.Excepciones;
using Utilidades;

namespace TestsValidaciones
{

    public partial class Validacion
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionAdmin_TokenVacio_Excepcion()
        {
            string token = "";
            validaciones.ValidarFormatoToken(token);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionAdmin_TokenNull_Excepcion()
        {
            validaciones.ValidarFormatoToken(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDatosAdmin))]
        public void ExisteSesionAdmin_TokenLargo_Excepcion()
        {

            string token = Util.StringAleatorio(1000);
            validaciones.ValidarFormatoToken(token);

        }
    }
}
