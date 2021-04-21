using LavaCar.AccesoDatos.Interfaces;
using LavaCar.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavaCar.AccesoDatos.Repositorios
{
    public class RepositorioServicio: IRepositorioServicio
    {
        private readonly LavaCarContext _context;

        public RepositorioServicio(LavaCarContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> ListarTodosLosServicios()
        {
            var listaDeServicios = await _context.Servicios.ToListAsync();

            return listaDeServicios;
        }

        public async Task AgregarServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task EditarServicio(Servicio servicioEditado)
        {
            _context.Servicios.Update(servicioEditado);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarServicio(int id)
        {
            var servicio = await ObtenerServicioPorId(id);

            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EliminarVehiculosDeServicio(int id)
        {
            var listaDeVehiculosEnServicio = _context.VehiculoServicios.Where(x => x.IdServicio == id);
            _context.VehiculoServicios.RemoveRange(listaDeVehiculosEnServicio);
            await _context.SaveChangesAsync();
        }

        public async Task<Servicio> ObtenerServicioPorId(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);

            return servicio;
        }

        public async Task<Servicio> ObtenerServicioConVehiculosPorId(int id)
        {
            var servicio = await _context.Servicios.Where(x => x.IdServicio == id)
                                                    .Include(x => x.VehiculoServicios)
                                                    .FirstOrDefaultAsync();

            return servicio;
        }

        public async Task<Servicio> VerificarExistenciaDeServicio(Servicio nuevoServicio)
        {
            var resultado = _context.Servicios.Where(servicio =>
            servicio.Descripcion.Equals(nuevoServicio.Descripcion) &&
            servicio.IdServicio != nuevoServicio.IdServicio);

            return await resultado.FirstOrDefaultAsync();
        }
    }
}
