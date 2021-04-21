using LavaCar.Entidades;
using LavaCar.Entidades.Enum;
using LavaCar.LogicaNegocio;
using LavaCar.LogicaNegocio.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LavaCar.UI.Controllers
{
    public class ServicioController : Controller
    {
        private readonly LogicaServicio _logicaServicio;

        public ServicioController(LogicaServicio logicaServicio)
        {
            _logicaServicio = logicaServicio;
        }

        public ActionResult ListaDeServicios()
        {

            return View();
        }

        public async Task<JsonResult> ListarServicios()
        {
            try
            {
                var listaDeServicios = await _logicaServicio.ListarTodosLosServicios();

                return Json(new { listaServicios = listaDeServicios });
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en el método ListarServicios()", e);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AgregarServicio(Servicio servicio)
        {
            Respuesta respuesta;

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta = await _logicaServicio.AgregarServicio(servicio);

                    return Json(respuesta);

                }
                else
                {

                    respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Incorrecto, "") };

                    return Json(respuesta);
                }

            }
            catch (Exception e)
            {
                respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorSolicitud, "") };

                return Json(respuesta);

                throw new Exception("Se ha producido un error en el método AgregarServicio()", e);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditarServicio(Servicio servicio)
        {
            Respuesta respuesta;

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta = await _logicaServicio.EditarServicio(servicio);

                    return Json(respuesta);

                }
                else
                {

                    respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Incorrecto, "") };

                    return Json(respuesta);
                }

            }
            catch (Exception e)
            {

                respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorSolicitud, "") };

                return Json(respuesta);

                throw new Exception("Se ha producido un error en el método EditarServicio()", e);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EliminarServicio(int id)
        {
            Respuesta respuesta;

            try
            {
                respuesta = await _logicaServicio.EliminarServicio(id);

                return Json(respuesta);

            }
            catch (Exception e)
            {

                respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorSolicitud, "") };

                return Json(respuesta);

                throw new Exception("Se ha producido un error en el método EliminarServicio()", e);
            }

        }
    }
}
