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
                Session["FechaIni"] = busqueda.CheckIn;
                Session["FechaFin"] = busqueda.CheckOut;
                Session["Camas"] = busqueda.Camas;
                return RedirectToAction("Index", "Habitacion");
            }
            else
            {
                Session["FechaIni"] = null;
                Session["FechaFin"] = null;
                Session["Camas"] = null;
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