using Booking.Business;
using BookingModels;
using System.Web.Mvc;

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var RegistroBusiness = new RegistroBusiness();

            if (RegistroBusiness.ExisteDni(model.Dni))
            {
                TempData["ErrorMessage_ExisteDni"] = "Dni ya se encuentra registrado.";
                return Index();
            }

            if (!RegistroBusiness.EsDniValido(model.Dni))
            {
                TempData["ErrorMessage_ExisteDni"] = "Dni ingresado no es válido.";
                return Index();
            }
            
            RegistroBusiness.RegistrarMiembro(model);
            RegistroBusiness.EnviarCorreoBienvenida(model.Correo, model.Nombres);
            TempData["OkMessage"] = "Mimebro registrado satisfactoriamente.";

            return View(model);
        }

        public ActionResult MisDatos()
        {
            return View();
        }
    }
}