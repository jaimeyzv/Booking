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

        [HttpPost]
        public ActionResult Index(Registro model)
        {
            var RegistroBusiness = new RegistroBusiness();

            if (RegistroBusiness.EsDniValido(model.Dni))
            {
                TempData["ErrorMessage_ExisteDni"] = "Dni ingresado no es válido.";
                return Index();
            }
            if (RegistroBusiness.ExisteDni(model.Dni))
            {
                TempData["ErrorMessage_ExisteDni"] = "Dni ya se encuentra registrado.";
                return Index();
            }
            
            RegistroBusiness.RegistrarMiembro(model);
            return View(model);
        }
    }
}