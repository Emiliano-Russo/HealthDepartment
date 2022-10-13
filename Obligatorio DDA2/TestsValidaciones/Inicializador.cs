using Interfaces.Validaciones;
using LogicaNegocio.Validaciones.Implementaciones;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Repositorio.RepositorioBDD;
using Utilidades.OperacionesEntidades;

namespace TestsValidaciones
{
    [TestClass]
    public partial class Validacion
    {
        IRepositorio repositorio;
        IValidacionEntidades validaciones;
        OperacionesPsicologia opPsicologia;

        [TestInitialize]
        public void Inicializar()
        {
            var opciones = new DbContextOptionsBuilder<EntidadesContexto>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            this.repositorio = new RepositorioBDD(opciones);
            this.validaciones = new ValidacionEntidades(this.repositorio);
            opPsicologia = new OperacionesPsicologia(this.repositorio);
        }
    }
}
