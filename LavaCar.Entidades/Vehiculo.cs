using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LavaCar.Entidades
{
    [Table("Vehiculo")]
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            VehiculoServicios = new HashSet<VehiculoServicio>();
        }

        [Key]
        [Column("ID_Vehiculo")]
        public int IdVehiculo { get; set; }
  
        [StringLength(30)]
        [Required(ErrorMessage = "El campo placa es obligatorio.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El campo dueño es obligatorio."), Display(Name = "Dueño")]
        public string Dueno { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El campo marca es obligatorio.")]
        public string Marca { get; set; }

        [NotMapped]
        [Display(Name = "Servicios a realizar")]
        public int[] ListaIdServicios { get; set; }

        [InverseProperty(nameof(VehiculoServicio.IdVehiculoNavigation))]
        public virtual ICollection<VehiculoServicio> VehiculoServicios { get; set; }
    }
}
