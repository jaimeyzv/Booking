using System.ComponentModel.DataAnnotations;

namespace BookingModels
{
    public class BusquedaHome
    {
        [Display(Name = "CheckIn")]
        [Required(ErrorMessage ="Debe ingresar CheckIn")]
        public string CheckIn { get; set; }

        [Display(Name = "CheckOut")]
        [Required(ErrorMessage = "Debe ingresar CheckOut")]
        public string CheckOut { get; set; }

        [Display(Name = "Huéspedes")]
        [Required(ErrorMessage = "Debe ingresar Cantidad")]
        public int Camas { get; set; }
    }
}