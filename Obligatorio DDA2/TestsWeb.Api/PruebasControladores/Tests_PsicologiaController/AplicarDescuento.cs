using Entidades;
using LogicaNegocio;
using LogicaNegocio.Excepciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Obligatorio_DDA2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Administracion;
using Web.Api.Entidades;

namespace TestsWeb.Api.PruebasControladores.Tests_PsicologiaController
{
    public partial class UnitTest_PsicologiaController
    {
        [TestMethod]
        public void AplicarDescuento_DatosCorrectos_Ok()
        {
            Descuento descuento = new Descuento
            {
                Email = "fabi@gmail.com",
                Porcentaje = 25
            };
            mock.Setup(sistema => sistema.AplicarDescuento(descuento));
            PsicologiaController psicologiaController = new PsicologiaController(mock.Object);
            JsonResult jsonResult = psicologiaController.AplicarDescuento(descuento,this.token);
            string mensaje = ((RespuestaJson)jsonResult.Value).Mensaje.ToString();
            string esperado = "Descuento Aplicado";
            Assert.AreEqual(esperado, mensaje);
        }
    }
}
