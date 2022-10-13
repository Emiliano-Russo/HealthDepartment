using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilidades;

namespace TestsRepositorio
{
    public partial class Repositorio
    {

        [TestMethod]
        public void GetCategoriasMusicales_SinExpeciones()
        {
            List<CategoriaMusical> listaCategoriaMusical = repositorio.GetCategoriasMusicales();
            bool catCuerpo = listaCategoriaMusical.Contains(CategoriaMusical.Cuerpo);
            bool catDormir = listaCategoriaMusical.Contains(CategoriaMusical.Dormir);
            bool catMeditar = listaCategoriaMusical.Contains(CategoriaMusical.Meditar);
            bool catMusica = listaCategoriaMusical.Contains(CategoriaMusical.Musica);
            Assert.IsTrue(catCuerpo && catMusica && catMeditar && catDormir);
        }
    }
}
