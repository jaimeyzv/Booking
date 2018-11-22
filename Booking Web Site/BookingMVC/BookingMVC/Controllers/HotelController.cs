using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    public class HotelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}