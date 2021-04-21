using LavaCar.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavaCar.AccesoDatos.Interfaces
{
    public interface IRepositorioServicio
    {
        Task<List<Servicio>> ListarTodosLosServicios();

        Task AgregarServicio(Servicio servicio);

        Task EditarServicio(Servicio servicio);

        Task EliminarServicio(int id);

        Task EliminarVehiculosDeServicio(int id);

        Task<Servicio> ObtenerServicioPorId(int id);

        Task<Servicio> ObtenerServicioConVehiculosPorId(int id);

        Task<Servicio> VerificarExistenciaDeServicio(Servicio servicio);
    }
}
