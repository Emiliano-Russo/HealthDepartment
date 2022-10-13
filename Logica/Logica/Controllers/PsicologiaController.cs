using Entidades;
using Interfaces;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Api.Administracion;
using Web.Api.Entidades;

namespace Obligatorio_DDA2.Controllers
{
    public class PsicologiaController : Controller
    {

        private ISistema sistema;
        private Direccion direccion;

        public PsicologiaController(ISistema sistema)
        {
            this.sistema = sistema;
            direccion = new Direccion(this);
        }

        public JsonResult Index()
        {
            try
            {
                List<CategoriaDolencia> lista = sistema.GetProblematicas();
                return direccion.Respuesta(lista);
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpPost]
        public JsonResult PedirCita([FromBody] Paciente paciente)
        {
            try
            {
                Cita cita = sistema.AgendarCita(paciente);
                return direccion.Respuesta(cita);
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e);
            }
        }

        [HttpPost]
        public JsonResult RegistrarPsicologo([FromBody] Psicologo psicologo, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.AltaPsicologo(psicologo);
                    return direccion.Respuesta("Psicologo guardado");
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

        [HttpGet]
        public JsonResult GetTodosLosPsicologos([FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    List<Psicologo> lista = sistema.GetTodosLosPsicologos();
                    return direccion.Respuesta(lista);
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

        [HttpPatch]
        public JsonResult ModificarPsicologo([FromBody] Psicologo psicologo, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.ModificarPsicologo(psicologo.ID, psicologo);
                    return direccion.Respuesta("Psicologo modificado");
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

        [HttpDelete]
        public JsonResult EliminarPsicologo([FromBody] int id, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.BajaPsicologo(id);
                    return direccion.Respuesta("Psicologo eliminado");
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

        [HttpGet]
        public JsonResult TraerMailsAptosParaDescuentos()
        {
            try
            {
                List<string> lista = sistema.TraerMailsAptosParaDescuento();
                return direccion.Respuesta(lista);
            }
            catch (Exception e)
            {
                return direccion.Respuesta(e.Message);
            }
        }

        [HttpPost]
        public JsonResult AplicarDescuento([FromBody] Descuento descuento, [FromHeader] string token)
        {
            try
            {
                if (sistema.ExisteSesionAdmin(token))
                {
                    sistema.AplicarDescuento(descuento);
                    return direccion.Respuesta("Descuento Aplicado");
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
    }
}
