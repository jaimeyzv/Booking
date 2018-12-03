using System.ComponentModel.DataAnnotations;

namespace BookingModels
{
    public class Registro
    {
        [Required(ErrorMessage = "Debe ingresar Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Debe ingresar Apellido Paterno")]
        [Display(Name ="Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Debe ingresar Apellido Materno")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Debe ingresar Dni")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Debe ingresar Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Debe ingresar Correo")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Debe ingresar Contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}