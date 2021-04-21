using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LavaCar.Entidades
{
    [Table("Vehiculo-Servicio")]
    public partial class VehiculoServicio
    {
        [Key]
        [Column("ID_Vehiculo-Servicio")]
        public int IdVehiculoServicio { get; set; }
        [Column("ID_Servicio")]
        public int IdServicio { get; set; }
        [Column("ID_Vehiculo")]
        public int IdVehiculo { get; set; }

        [ForeignKey(nameof(IdServicio))]
        [InverseProperty(nameof(Servicio.VehiculoServicios))]
        public virtual Servicio IdServicioNavigation { get; set; }
        [ForeignKey(nameof(IdVehiculo))]
        [InverseProperty(nameof(Vehiculo.VehiculoServicios))]
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
