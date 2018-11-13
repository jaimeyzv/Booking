using BookingMVC.Models;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    public class RegistroController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar(RegistroModel model)
        {
            return View();
        }
    }
}