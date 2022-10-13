using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicaNegocio;
using System.Collections.Generic;
using System;
using Entidades;

namespace TestsLogicaNegocio
{
    public partial class SistemaTest
    {
        [TestMethod]
        public void GetCategoriasMusicales_asd_SinExpeciones()
        {
            List<CategoriaMusical> listaCategoriaMusical = sistema.GetCategoriasMusicales();
            bool catCuerpo = listaCategoriaMusical.Contains(CategoriaMusical.Cuerpo);
            bool catDormir = listaCategoriaMusical.Contains(CategoriaMusical.Dormir);
            bool catMeditar = listaCategoriaMusical.Contains(CategoriaMusical.Meditar);
            bool catMusica = listaCategoriaMusical.Contains(CategoriaMusical.Musica);
            Assert.IsTrue(catCuerpo && catMusica && catMeditar && catDormir);
        }
    }
}
