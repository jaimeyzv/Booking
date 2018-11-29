using BookingMVC.Filter;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    [AuthUserFilter]
    public class HotelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}