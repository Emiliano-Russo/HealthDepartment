using Entidades;
using Interfaces;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Administracion;

namespace Obligatorio_DDA2.Controllers
{
    public class AdminController : Controller
    {
        private ISistema sistema;
        private Direccion direccion;

        public AdminController(ISistema sistema)
        {
            this.sistema = sistema;
            direccion = new Direccion(this);
        }

        public void Index()
        {

        }

        [HttpPost]
        public JsonResult AgregarAdmin([FromBody] Admin admin, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionSuperAdmin(token))
                {                   
                    sistema.AgregarAdmin(admin);
                    return direccion.Respuesta("Admin Registrado");
                }
                else
                {
                    return direccion.RespuestaSesionInactiva();
                }
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpPost]
        public JsonResult Login([FromBody] Admin admin)
        {
            try
            {
                string token = sistema.IniciarSesion(admin);
                return direccion.Respuesta(token);
            }
            catch(Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

    }
}
