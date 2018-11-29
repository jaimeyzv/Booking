using Booking.Business;
using BookingModels;
using BookingMVC.Filter;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    [AuthUserFilter]
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
                var miembro = autenticacionBusiness.IniciarSesion(model.Dni, model.Contrasena);
                if (miembro != null)
                {
                    Session["Miembro"] = miembro;
                    return RedirectToAction("../Home/Index");
                }
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