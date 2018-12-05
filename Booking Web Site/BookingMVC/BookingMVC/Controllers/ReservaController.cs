using Booking.Business;
using Booking.Business.MemberService;
using BookingMVC.Filter;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    [AuthUserFilter]
    public class ReservaController : Controller
    {
        ReservaBusiness reservaBusiness = new ReservaBusiness();

        public ActionResult Index()
        {
            var miembro = Session["Miembro"] as Miembro;
            var reservas = reservaBusiness.ListarReservas(miembro.Dni);
            return View(reservas);
        }
    }
}