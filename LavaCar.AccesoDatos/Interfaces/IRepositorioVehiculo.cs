using LavaCar.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LavaCar.AccesoDatos.Interfaces
{
    public interface IRepositorioVehiculo
    {
        Task<List<Vehiculo>> ListarTodosLosVehiculos();

        Task<List<Vehiculo>> ListarVehiculosPorServicio(int id);

        Task<Vehiculo> AgregarVehiculo(Vehiculo vehiculo);

        Task EditarVehiculo(Vehiculo vehiculo);

        Task EliminarVehiculo(int id);

        Task EliminarServiciosDeVehiculo(int id);

        Task<Vehiculo> ObtenerVehiculoPorId(int id);

        Task<Vehiculo> ObtenerVehiculoConServiciosPorId(int id);

        Task<List<VehiculoServicio>> ObtenerServiciosDeVehiculo(int id);

        Task AgregarServiciosDeVehiculo(List<VehiculoServicio> listaDeServiciosDeVehiculo);

        Task<Vehiculo> VerificarExistenciaDeVehiculo(Vehiculo vehiculo);
        
    }
}
