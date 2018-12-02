using System.ComponentModel.DataAnnotations;

namespace BookingModels
{
    public class Login
    {
        [Required(ErrorMessage ="Debe ingresar DNI")]
        [StringLength(8, ErrorMessage = "DNI debe tener 8 dígitos", MinimumLength = 8)]
        [Display(Name = "DNI")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Contraseña no debe ser menor de 6 caracteres", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}