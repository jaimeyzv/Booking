using Booking.Business.BookService;
using Booking.Business.HotelService;
using Booking.Business.RoomService;
using System.Collections.Generic;

namespace BookingMVC.Models
{
    public class ReservaHistorial
    {
        public List<Reserva> Reservas { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public List<Hotels> Hoteles { get; set; }
    }
}