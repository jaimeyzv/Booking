using Booking.Business;
using BookingModels;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    public class IniciarSesionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                var autenticacionBusiness = new AutenticacionBusiness();
                if (autenticacionBusiness.IniciarSesion(model.Dni, model.Contrasena) != null)
                    return RedirectToAction("../Home/Index");
                else
                {
                    TempData["ErrorMessage_Login"] = "Dni y/o contraseña inválidos";
                    return Index();
                }
            }
            else
                return View();
        }
    }
}