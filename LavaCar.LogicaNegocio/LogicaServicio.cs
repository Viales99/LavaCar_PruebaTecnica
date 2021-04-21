using LavaCar.AccesoDatos.Interfaces;
using LavaCar.Entidades;
using LavaCar.Entidades.Enum;
using LavaCar.LogicaNegocio.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavaCar.LogicaNegocio
{
    public class LogicaServicio
    {
        private readonly IRepositorioServicio _repositorioServicio;

        public LogicaServicio(IRepositorioServicio repositorioServicio)
        {
            _repositorioServicio = repositorioServicio;
        }

        public async Task<List<Servicio>> ListarTodosLosServicios()
        {
            var listaDeServicios = await _repositorioServicio.ListarTodosLosServicios();

            return listaDeServicios;
        }

        public async Task<Respuesta> AgregarServicio(Servicio servicio)
        {
            Respuesta respuesta;

            bool yaExiste = await VerificarExistenciaDeServicio(servicio);

            if (!yaExiste)
            {
                await _repositorioServicio.AgregarServicio(servicio);

                respuesta = new Respuesta { Ok = true, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Agregado, "El servicio") };

            }
            else
            {
                return respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorYaExiste, "El servicio") };
            }

            return respuesta;
        }

        public async Task<Respuesta> EditarServicio(Servicio servicioEditado)
        {
            Respuesta respuesta;

            bool yaEditada = await VerificarEdicionDeServicio(servicioEditado);

            if (yaEditada)
            {
                bool yaExiste = await VerificarExistenciaDeServicio(servicioEditado);

                if (!yaExiste)
                {
                    var servicioExistente = await ObtenerServicioPorId(servicioEditado.IdServicio);

                    servicioExistente.Descripcion = servicioEditado.Descripcion;
                    servicioExistente.Monto = servicioEditado.Monto;

                    await _repositorioServicio.EditarServicio(servicioExistente);

                    return respuesta = new Respuesta { Ok = true, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Editado, "El servicio") };

                }
                else
                {
                    return respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorYaExiste, "El servicio") };
                }
            }
            else
            {

                return respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorEditar, "") };

            }

        }

        public async Task<Respuesta> EliminarServicio(int id)
        {
            Respuesta respuesta;

            var poseeServicios = await VerificarExistenciaDeVehiculos(id);

            if (poseeServicios)
            {
                await _repositorioServicio.EliminarVehiculosDeServicio(id);
            }

            await _repositorioServicio.EliminarServicio(id);

            return respuesta = new Respuesta { Ok = true, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Eliminado, "El servicio") };
        }

        public async Task<bool> VerificarExistenciaDeVehiculos(int id)
        {
            var servicio = await _repositorioServicio.ObtenerServicioConVehiculosPorId(id);

            var existenciaDeServicios = servicio.VehiculoServicios.Count != 0;

            return existenciaDeServicios;
        }


        public async Task<Servicio> ObtenerServicioPorId(int id)
        {
            return await _repositorioServicio.ObtenerServicioPorId(id);
        }

        public async Task<bool> VerificarExistenciaDeServicio(Servicio servicio)
        {
            var servicioExistente = await _repositorioServicio.VerificarExistenciaDeServicio(servicio);

            bool respuesta = servicioExistente != null;

            return respuesta;
        }


        public async Task<bool> VerificarEdicionDeServicio(Servicio servicioEditado)
        {
            var servicioExistente = await _repositorioServicio.ObtenerServicioPorId(servicioEditado.IdServicio);

            bool respuesta;

            if (servicioExistente.Descripcion != servicioEditado.Descripcion
                || servicioExistente.Monto != servicioEditado.Monto)
            {

                respuesta = true;

            }
            else
            {

                respuesta = false;
            }

            return respuesta;
        }

    }
}
