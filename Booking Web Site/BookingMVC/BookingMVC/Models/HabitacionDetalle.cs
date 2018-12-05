using Booking.Business.RoomService;
using System.ComponentModel.DataAnnotations;

namespace BookingMVC.Models
{
    public class HabitacionDetalle
    {
        public Habitacion Habitacion { get; set; }

        [Required(ErrorMessage ="Debe Seleccionar una fecha")]
        public string CheckIn { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar una fecha")]
        public string CheckOut { get; set; }
    }
}