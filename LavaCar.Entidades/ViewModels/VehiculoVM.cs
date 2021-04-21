using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LavaCar.Entidades.ViewModels
{
    public class VehiculoVM
    {
        public int IdVehiculo { get; set; }

        [Required(ErrorMessage = "El campo placa es obligatorio.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El campo Dueño es obligatorio."), Display(Name = "Dueño")]
        public string Dueno { get; set; }

        [Required(ErrorMessage = "El campo marca es obligatorio.")]
        public string Marca { get; set; }

    }
}
