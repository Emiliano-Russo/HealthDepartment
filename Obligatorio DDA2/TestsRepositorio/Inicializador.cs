using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositorio.Repositorio.RepositorioBDD;
using Utilidades;
using Utilidades.OperacionesEntidades;

namespace TestsRepositorio
{
    [TestClass]
    public partial class Repositorio
    {
        private IRepositorio repositorio;
        private OperacionesPsicologia opPsicologia;
        private OperacionesMusica opMusica;
        private DatosGlobalesMusica datosGlobalesMusica;

        [TestInitialize]
        public void Inicializar()
        {
            var opciones = new DbContextOptionsBuilder<EntidadesContexto>()
                .UseInMemoryDatabase(databaseName:"Test")
                .Options;
             this.repositorio = new RepositorioBDD(opciones);
            this.opPsicologia = new OperacionesPsicologia(repositorio);
            this.opMusica = new OperacionesMusica(repositorio);
            this.datosGlobalesMusica = new DatosGlobalesMusica(repositorio);
        }

        [TestCleanup]
        public void Limpiar()
        {
            this.repositorio.BorrarTodosLosDatos();
        }

    }
}
