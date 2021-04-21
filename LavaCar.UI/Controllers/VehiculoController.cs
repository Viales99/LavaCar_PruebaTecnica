using LavaCar.Entidades;
using LavaCar.Entidades.Enum;
using LavaCar.LogicaNegocio;
using LavaCar.LogicaNegocio.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavaCar.UI.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly LogicaVehiculo _logicaVehiculo;

        public VehiculoController(LogicaVehiculo logicaVehiculo)
        {
            _logicaVehiculo = logicaVehiculo;
        }

        public ActionResult ListaDeVehiculos()
        {

            return View();
        }

        public async Task<JsonResult> ListarVehiculos()
        {
            try
            {
                var listaDeVehiculos = await _logicaVehiculo.ListarTodosLosVehiculos();

                return Json(new { listaVehiculos = listaDeVehiculos });
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en el método ListarVehiculos()", e);
            }
        }

        public async Task<JsonResult> ListarVehiculosPorServicio(int? id)
        {
            try
            {
                List<Vehiculo> listaDeVehiculos;

                if (id != null)
                {
                    listaDeVehiculos = await _logicaVehiculo.ListarVehiculosPorServicio((int)id);
                }
                else
                {

                    listaDeVehiculos = new List<Vehiculo>();
                }

                return Json(new { listaVehiculos = listaDeVehiculos });
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en el método ListarVehiculosPorServicio()", e);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AgregarVehiculo(Vehiculo vehiculo)
        {
            Respuesta respuesta;

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta = await _logicaVehiculo.AgregarVehiculo(vehiculo);

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

                throw new Exception("Se ha producido un error en el método AgregarVehiculo()", e);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditarVehiculo(Vehiculo vehiculo)
        {
            Respuesta respuesta;

            try
            {
                if (ModelState.IsValid)
                {
                    respuesta = await _logicaVehiculo.EditarVehiculo(vehiculo);

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

                respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorSolicitud, e.Message) };

                return Json(respuesta);

                throw new Exception("Se ha producido un error en el método EditarVehiculo()", e);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EliminarVehiculo(int id)
        {
            Respuesta respuesta;

            try
            {
                respuesta = await _logicaVehiculo.EliminarVehiculo(id);

                return Json(respuesta);

            }
            catch (Exception e)
            {

                respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorSolicitud, "") };

                return Json(respuesta);

                throw new Exception("Se ha producido un error en el método EliminarVehiculo()", e);
            }

        }

        public async Task<JsonResult> ObtenerIdServiciosDeVehiculo(int id)
        {
            try
            {
                var ListaIdServicios = await _logicaVehiculo.ObtenerIdServiciosDeVehiculo(id);

                return Json(ListaIdServicios);

            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error en el método ObtenerIdServiciosDeVehiculo()", e);
            }

        }

    }
}
