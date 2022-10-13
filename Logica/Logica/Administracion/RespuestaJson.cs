using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Administracion
{
    public class RespuestaJson
    {
        public int Codigo { get; set; }

        public object Mensaje { get; set; }

        public RespuestaJson()
        {
            this.Codigo = 200;
            this.Mensaje = "Operacion realizada con exito";
        }

        public RespuestaJson(int codigo, Exception e)
        {
            this.Codigo = codigo;
            this.Mensaje = e.Message;
        } 

        public RespuestaJson(object mensaje)
        {
            this.Codigo = 200;
            this.Mensaje = mensaje;
        }

        public RespuestaJson(int codigo, string mensaje)
        {
            this.Codigo = codigo;
            this.Mensaje = mensaje;
        }

        public JsonResult GetRespuesta(Controller controller)
        {
            return controller.Json(this);
        }
     
    }
}
