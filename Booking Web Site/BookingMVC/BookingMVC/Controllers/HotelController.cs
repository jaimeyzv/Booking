using Booking.Business;
using BookingMVC.Filter;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    [AuthUserFilter]
    public class HotelController : Controller
    {
        HotelesBusiness hotelesBusiness = new HotelesBusiness();

        public ActionResult Index()
        {
            var hoteles = hotelesBusiness.ListarHoteles();
            return View(hoteles);
        }
    }
}