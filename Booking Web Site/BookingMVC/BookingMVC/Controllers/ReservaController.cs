using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        // POST: Reserva
        //[HttpPost]
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}