using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsWeb.Api.PruebasControladores
{
    internal class ConfiguracionHTTP
    {
        internal void ConfigurarHttpResponse(Controller controlador)
        {
            var response = new Mock<HttpResponse>();

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);

            controlador.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }
    }
}
