using LavaCar.AccesoDatos.Interfaces;
using LavaCar.Entidades;
using LavaCar.Entidades.Enum;
using LavaCar.LogicaNegocio.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavaCar.LogicaNegocio
{
    public class LogicaVehiculo
    {
        private readonly IRepositorioVehiculo _repositorioVehiculo;

        public LogicaVehiculo(IRepositorioVehiculo repositorioVehiculo)
        {
            _repositorioVehiculo = repositorioVehiculo;
        }

        public async Task<List<Vehiculo>> ListarTodosLosVehiculos()
        {
            var listaDeVehiculos = await _repositorioVehiculo.ListarTodosLosVehiculos();

            return listaDeVehiculos;
        }

        public async Task<List<Vehiculo>> ListarVehiculosPorServicio(int id)
        {
            return await _repositorioVehiculo.ListarVehiculosPorServicio(id);
        }

        public async Task<Respuesta> AgregarVehiculo(Vehiculo vehiculo)
        {
            Respuesta respuesta;

            bool yaExiste = await VerificarExistenciaDeVehiculo(vehiculo);

            if (!yaExiste)
            {
                var vehiculoAgregado = await _repositorioVehiculo.AgregarVehiculo(vehiculo);

                if(vehiculo.ListaIdServicios != null) { 

                    vehiculo.IdVehiculo= vehiculoAgregado.IdVehiculo;
                    await AgregarServiciosDeVehiculo(vehiculo);
                }

                respuesta = new Respuesta { Ok = true, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Agregado, "El vehículo") };

            }
            else
            {
                return respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorYaExiste, "El vehículo") };
            }

            return respuesta;
        }

        public async Task<Respuesta> EditarVehiculo(Vehiculo vehiculoEditado)
        {
            Respuesta respuesta;

            var yaEditado = await VerificarEdicionDeVehiculo(vehiculoEditado);

            var serviciosEditados = await ComprobarEdicionDeServiciosDeVehiculo(vehiculoEditado);

            if (yaEditado || serviciosEditados)
            {
                bool yaExiste = await VerificarExistenciaDeVehiculo(vehiculoEditado);

                if (!yaExiste)
                {
                    if (yaEditado)
                    {
                        var vehiculoExistente = await ObtenerVehiculoPorId(vehiculoEditado.IdVehiculo);

                        vehiculoExistente.Placa = vehiculoEditado.Placa;
                        vehiculoExistente.Dueno = vehiculoEditado.Dueno;
                        vehiculoExistente.Marca = vehiculoEditado.Marca;

                        await _repositorioVehiculo.EditarVehiculo(vehiculoExistente);
                    }

                    if (serviciosEditados)
                    {
                        await EditarServiciosDeVehiculo(vehiculoEditado);
                    }

                    return respuesta = new Respuesta { Ok = true, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Editado, "El vehículo") };

                }
                else
                {
                    return respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorYaExiste, "El vehículo") };
                }
            }
            else
            {

                return respuesta = new Respuesta { Ok = false, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.ErrorEditar, "") };

            }

        }

        public async Task<Respuesta> EliminarVehiculo(int id)
        {
            Respuesta respuesta;

            var poseeServicios = await VerificarExistenciaDeServicios(id);

            if (poseeServicios)
            {
                await _repositorioVehiculo.EliminarServiciosDeVehiculo(id);
            }

            await _repositorioVehiculo.EliminarVehiculo(id);

            return respuesta = new Respuesta { Ok = true, Mensaje = HelperMensaje.GenerarMensaje(TipoMensaje.Eliminado, "El vehículo") };
        }

        public async Task<bool> VerificarExistenciaDeServicios(int id)
        {
            var vehiculo = await _repositorioVehiculo.ObtenerVehiculoConServiciosPorId(id);

            var existenciaDeServicios = vehiculo.VehiculoServicios.Count != 0;

            return existenciaDeServicios;
        }


        public async Task<Vehiculo> ObtenerVehiculoPorId(int id)
        {
            return await _repositorioVehiculo.ObtenerVehiculoPorId(id);
        }

        public async Task<int[]> ObtenerIdServiciosDeVehiculo(int id)
        {
            var listaServiciosDeVehiculo = await ObtenerServiciosDeVehiculo(id);

            List<int> ListaIdServicios = new List<int>();

            foreach (VehiculoServicio vehiculoServicio in listaServiciosDeVehiculo)
            {
                ListaIdServicios.Add(vehiculoServicio.IdServicio);
            }

            return ListaIdServicios.ToArray();
        }

        public async Task<List<VehiculoServicio>> ObtenerServiciosDeVehiculo(int id)
        {
            return await _repositorioVehiculo.ObtenerServiciosDeVehiculo(id);
        }

        public async Task<bool> VerificarExistenciaDeVehiculo(Vehiculo vehiculo)
        {
            var vehiculoExistente = await _repositorioVehiculo.VerificarExistenciaDeVehiculo(vehiculo);

            bool respuesta = vehiculoExistente != null;

            return respuesta;
        }

        public async Task AgregarServiciosDeVehiculo(Vehiculo vehiculo)
        {
            List<VehiculoServicio> listaDeServiciosDeVehiculo = new List<VehiculoServicio>();

            foreach (int idServicio in vehiculo.ListaIdServicios)
            {
                VehiculoServicio marcaFamilia = new VehiculoServicio { IdVehiculo = vehiculo.IdVehiculo, IdServicio = idServicio };
                listaDeServiciosDeVehiculo.Add(marcaFamilia);
            }

            await _repositorioVehiculo.AgregarServiciosDeVehiculo(listaDeServiciosDeVehiculo);
        }

        public async Task EditarServiciosDeVehiculo(Vehiculo vehiculo)
        {
            await _repositorioVehiculo.EliminarServiciosDeVehiculo(vehiculo.IdVehiculo);

            if(vehiculo.ListaIdServicios != null)
                await AgregarServiciosDeVehiculo(vehiculo);
        }


        public async Task<bool> VerificarEdicionDeVehiculo(Vehiculo vehiculoEditado)
        {
            var vehiculoExistente = await _repositorioVehiculo.ObtenerVehiculoPorId(vehiculoEditado.IdVehiculo);

            bool respuesta;

            if (vehiculoExistente.Dueno != vehiculoEditado.Dueno
                || vehiculoExistente.Placa != vehiculoEditado.Placa
                || vehiculoExistente.Marca != vehiculoEditado.Marca)
            {

                respuesta = true;

            }
            else
            {

                respuesta = false;
            }

            return respuesta;
        }

        public async Task<bool> ComprobarEdicionDeServiciosDeVehiculo(Vehiculo vehiculo)
        {
            var listaServiciosDeVehiculo = await ObtenerServiciosDeVehiculo(vehiculo.IdVehiculo);

            var respuesta = false;

            if (vehiculo.ListaIdServicios != null && vehiculo.ListaIdServicios.Length == listaServiciosDeVehiculo.Count)
            {
                foreach (int idServicio in vehiculo.ListaIdServicios)
                {
                    if (!listaServiciosDeVehiculo.Exists(servicio => servicio.IdServicio == idServicio))
                    {
                        respuesta = true;
                        return respuesta;
                    }
                }
            }
            else
            {
                respuesta = true;
                return respuesta;
            }

            return respuesta;
        }

    }
}
