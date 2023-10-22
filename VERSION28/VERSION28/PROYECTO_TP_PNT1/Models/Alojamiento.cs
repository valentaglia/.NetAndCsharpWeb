using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_TP_PNT1.Models
{
    public class Alojamiento 
    {   

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public int idAlojamiento { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombre { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "La direccion es obligatoria.")]
        public string direccion { get; set; }

        [Display(Name = "Habitaciones disponibles")]
        [Required(ErrorMessage = "La cantidad de habitaciones es obligatoria.")]
        public int cantHabitacionesDisponibles { get; set; }
        
        [Display(Name = "Capacidad por habitacion")]
        [Required(ErrorMessage = "Debe ingresar la capacidad de cada habitacion")]
        public int capacidadHabitaciones { get; set; }

        [EnumDataType(typeof(TipoDeAlojamiento))]
        [Required(ErrorMessage = "El tipo es obligatorio.")]
        [Display(Name = "Alojamiento de tipo")]
        public TipoDeAlojamiento tipo { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        [Display(Name = "Precio de alojamiento")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public double precio { get; set; }

        [Range(0, double.MaxValue , ErrorMessage = "El precio debe ser mayor a 0.")]
        [Display(Name = "Precio de desayuno por persona")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public double precioDesayuno { get; set; }
    }
}
