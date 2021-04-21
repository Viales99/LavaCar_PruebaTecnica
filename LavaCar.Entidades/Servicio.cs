using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LavaCar.Entidades
{
    public partial class Servicio
    {
        public Servicio()
        {
            VehiculoServicios = new HashSet<VehiculoServicio>();
        }

        [Key]
        [Column("ID_Servicio")]
        public int IdServicio { get; set; }

        [Required(ErrorMessage = "El campo descripción es obligatorio."), Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo monto es obligatorio.")]
        [Range(100, 100000, ErrorMessage = "El rango permitido es entre {1} y {2}")]
        public int Monto { get; set; }

        [InverseProperty(nameof(VehiculoServicio.IdServicioNavigation))]
        public virtual ICollection<VehiculoServicio> VehiculoServicios { get; set; }
    }
}
