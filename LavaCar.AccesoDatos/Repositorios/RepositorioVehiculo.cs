using LavaCar.AccesoDatos.Interfaces;
using LavaCar.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavaCar.AccesoDatos.Repositorios
{
    public class RepositorioVehiculo : IRepositorioVehiculo
    {
        private readonly LavaCarContext _context;

        public RepositorioVehiculo(LavaCarContext context)
        {
            _context = context;
        }

        public async Task<List<Vehiculo>> ListarTodosLosVehiculos()
        {
            var listaDeVehiculos = await _context.Vehiculos.ToListAsync();

            return listaDeVehiculos;
        }

        public async Task<List<Vehiculo>> ListarVehiculosPorServicio(int id)
        {
             var listaDeVehiculos = from Vehiculo in _context.Vehiculos
                                    join VehiculoServicio in _context.VehiculoServicios
                                    on Vehiculo.IdVehiculo equals VehiculoServicio.IdVehiculo
                                    join Servicio in _context.Servicios
                                    on VehiculoServicio.IdServicio equals Servicio.IdServicio
                                    where Servicio.IdServicio == id
                                    select Vehiculo;

            return await listaDeVehiculos.ToListAsync();
        }

        public async Task<Vehiculo> AgregarVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();

            return vehiculo;
        }

        public async Task EditarVehiculo(Vehiculo vehiculoEditado)
        {
            _context.Vehiculos.Update(vehiculoEditado);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarVehiculo(int id)
        {
           var vehiculo = await ObtenerVehiculoPorId(id);

            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarServiciosDeVehiculo(int id)
        {
           var listaDeServiciosDeVehiculo = _context.VehiculoServicios.Where(x => x.IdVehiculo == id);
            _context.VehiculoServicios.RemoveRange(listaDeServiciosDeVehiculo);
           await _context.SaveChangesAsync();
        }

        public async Task<Vehiculo> ObtenerVehiculoPorId(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            return vehiculo;
        }

        public async Task<Vehiculo> ObtenerVehiculoConServiciosPorId(int id)
        {
            var vehiculo = await _context.Vehiculos.Where(x => x.IdVehiculo == id)
                                                    .Include(x => x.VehiculoServicios)
                                                    .FirstOrDefaultAsync();

            return vehiculo;
        }

        public async Task<List<VehiculoServicio>> ObtenerServiciosDeVehiculo(int id)
        {
            var listaServiciosDeVehiculo = _context.VehiculoServicios.Where(vehiculoServicios => vehiculoServicios.IdVehiculo == id);
            return await listaServiciosDeVehiculo.ToListAsync();
        }

        public async Task AgregarServiciosDeVehiculo(List<VehiculoServicio> listaDeServiciosDeVehiculo)
        {
            _context.VehiculoServicios.AddRange(listaDeServiciosDeVehiculo);
            await _context.SaveChangesAsync();
            
        }

        public async Task<Vehiculo> VerificarExistenciaDeVehiculo(Vehiculo nuevoVehiculo)
        {
            var resultado = _context.Vehiculos.Where(vehiculo =>
            vehiculo.Placa.Equals(nuevoVehiculo.Placa) &&
            vehiculo.IdVehiculo != nuevoVehiculo.IdVehiculo);

            return await resultado.FirstOrDefaultAsync();
        }

    }
}
