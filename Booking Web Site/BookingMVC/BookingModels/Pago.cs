using System;
using System.ComponentModel.DataAnnotations;

namespace BookingModels
{
    public class Pago
    {
        public int TarjetaId { get; set; }

        [Display(Name = "Nombre Tarjeta")]
        [Required(ErrorMessage ="Debe ingresar nombre de tarjeta")]
        public string NombreTarjeta { get; set; }

        [Display(Name = "Número Tarjeta")]
        [Required(ErrorMessage = "Debe ingresar número de tarjeta")]
        public string NumeroTarjeta { get; set; }

        [Display(Name = "Fecha Expiración")]
        [Required(ErrorMessage = "Debe ingresar fecha expiracion")]
        public string FechaExpiracion { get; set; }

        [Display(Name = "CVV")]
        [Required(ErrorMessage = "Debe ingresar CVV")]
        public string CardCvv { get; set; }

        public decimal Costo { get; set; }
        public int HabitacionId { get; set; }
        public string Descripcion { get; set; }
    }
}