using BookingModels;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(BusquedaHome busqueda)
        {
            if (ModelState.IsValid)
            {
                Session["Busqueda"] = busqueda;
                return RedirectToAction("Index", "Habitacion");
            }
            else
            {
                return View(busqueda);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "IniciarSesion");
        }
    }
}