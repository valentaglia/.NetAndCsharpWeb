using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROYECTO_TP_PNT1.Models
{
    public class Reserva : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (entrada < DateTime.Today)
            {
                yield return new ValidationResult("La fecha seleccionada no puede ser menor a la actual", new[] { "entrada" });
            }
            if (salida < DateTime.Today)
            {
                yield return new ValidationResult("La fecha seleccionada no puede ser menor a la actual", new[] { "salida" });
            }
            if (entrada > salida)
            {
                yield return new ValidationResult("La fecha de egreso debe ser mayor a la fecha de ingreso", new[] { "entrada", "salida" });
            }

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idReserva { get; set; }
        [Display(Name = "Entrada")]
        [Required(ErrorMessage = "Debe ingresar entrada")]
        public DateTime entrada { get; set; }
        [Display(Name = "Salida")]
        [Required(ErrorMessage = "Debe ingresar salida")]
        public DateTime salida { get; set; }
        [Display(Name = "¿Desayuno incluido?")]
        public bool desayuno { get; set; }
        [Display(Name = "Cantidad personas")]
        [Required(ErrorMessage = "Ingrese cantidad de personas")]
        public int cantPersonas { get; set; }
        [Display(Name = "Cantidad habitaciones")]
        [Required(ErrorMessage = "Ingrese habitaciones")]
        public int CantHabitaciones { get; set; }

        [Display(Name = "idAlojamiento")]
        public int? idAlojamiento { get; set; }
        [Display(Name = "Alojamiento")]

        public virtual Alojamiento alojamiento { get; set; }

        [Display(Name = "idCliente")]
        public int? idCliente { get; set; }

        [Display(Name = "Cliente")]
        public virtual Cliente cliente { get; set; }


        [Display(Name = "Total")]
        public double precioTotal { get; set; }

        

    }
    }

