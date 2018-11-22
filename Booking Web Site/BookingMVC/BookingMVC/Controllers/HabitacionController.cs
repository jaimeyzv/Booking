using Booking.Business;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    public class HabitacionController : Controller
    {
        HabitacionesBusiness habitacionesBusiness = new HabitacionesBusiness();

        public ActionResult Index()
        {
            return View();
        }

        //[Route("Habitaciones")]
        public ActionResult Habitaciones()
        {
            var habitaciones = habitacionesBusiness.ListarHabitaciones();
            return View(habitaciones);
        }
    }
}