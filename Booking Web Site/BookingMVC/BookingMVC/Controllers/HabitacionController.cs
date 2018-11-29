using Booking.Business;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    public class HabitacionController : Controller
    {
        HabitacionesBusiness habitacionesBusiness = new HabitacionesBusiness();

        public ActionResult Index()
        {
            var habitaciones = habitacionesBusiness.ListarHabitaciones();
            return View(habitaciones);
        }

        public ActionResult Detalle(int id)
        {
            var habitacion = habitacionesBusiness.ObtenerHabitacion(id);
            return View(habitacion);
        }      
    }
}