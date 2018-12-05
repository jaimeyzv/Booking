using Booking.Business;
using Booking.Business.MemberService;
using BookingMVC.Filter;
using BookingMVC.Models;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    [AuthUserFilter]
    public class ReservaController : Controller
    {
        ReservaBusiness reservaBusiness = new ReservaBusiness();
        HabitacionesBusiness habitacionesBusiness = new HabitacionesBusiness();
        HotelesBusiness hotelesBusiness = new HotelesBusiness();

        public ActionResult Index()
        {
            var miembro = Session["Miembro"] as Miembro;
            var reservas = reservaBusiness.ListarReservas(miembro.Dni);
            var habitaciones = habitacionesBusiness.ListarHabitaciones();
            var hoteles = hotelesBusiness.ListarHoteles();
            var model = new ReservaHistorial();
            model.Reservas = reservas;
            model.Habitaciones = habitaciones;
            model.Hoteles = hoteles;

            return View(model);
        }
    }
}