using BookingModels;
using System.Web.Mvc;
using Booking.Business;

namespace BookingMVC.Controllers
{
    public class RegistroController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar(Registro model)
        {
            var RegistroBusiness = new RegistroBusiness();
            RegistroBusiness.RegistrarMiembro(model);
            return View();
        }
    }
}