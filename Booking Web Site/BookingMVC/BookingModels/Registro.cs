using System.ComponentModel.DataAnnotations;

namespace BookingModels
{
    public class Registro
    {
        public string Nombres { get; set; }
        [Display(Name ="Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}