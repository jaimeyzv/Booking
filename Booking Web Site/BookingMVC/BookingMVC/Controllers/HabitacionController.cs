using Booking.Business;
using BookingModels;
using BookingMVC.Filter;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    [AuthUserFilter]
    public class HabitacionController : Controller
    {
        HabitacionesBusiness habitacionesBusiness = new HabitacionesBusiness();

        public ActionResult Index()
        {
            var habitaciones = habitacionesBusiness.ListarHabitaciones();
            return View(habitaciones);
        }

        public ActionResult Detalle(int id)
        {
            var habitacion = habitacionesBusiness.ObtenerHabitacion(id);
            return View(habitacion);
        }

        public ActionResult Pago(int habitacionId)
        {
            TempData["MostrarPago"] = true;
            var pago = new Pago();
            pago.HabitacionId = habitacionId;
            return View(pago);
        }

        [HttpPost]
        public ActionResult Pago(Pago pago)
        {
            if (!ModelState.IsValid)
                return View(pago);
            else {
                var habitacion = habitacionesBusiness.ObtenerHabitacion(pago.HabitacionId);
                pago.Costo = habitacion.Precio;
                pago.Descripcion = "Reserva Habitacion " + habitacion.CodigoHabitacion;
                TarjetaBusiness tarjetaBusiness = new TarjetaBusiness();
                if (tarjetaBusiness.SonDatosValidos(pago))
                {
                    var tarjetaId = tarjetaBusiness.ObtenerTarjetaIdPorNumero(pago.NumeroTarjeta);
                    if (tarjetaBusiness.HaySaldo(pago.Costo, tarjetaId))
                    {
                        PagoBusiness pagoBusiness = new PagoBusiness();
                        if (pagoBusiness.Pagar(pago))
                        {
                            HabitacionesBusiness habitacionesBusiness = new HabitacionesBusiness();
                            habitacionesBusiness.ReservarHabitacion(habitacion.HabitacionId);
                            TempData["MostrarPago"] = null;
                            return View(pago);
                        }
                        else {
                            TempData["ErrorMessage"] = "Error el realizar el pago";
                            return View(pago);
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "No tiene saldo suficiente";
                        return View(pago);
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Datos de la tarjeta inválidos";
                    return View(pago);
                }
            }
        }
    }
}