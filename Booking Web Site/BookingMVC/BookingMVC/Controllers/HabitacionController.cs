using Booking.Business;
using Booking.Business.MemberService;
using Booking.Business.RoomService;
using BookingModels;
using BookingMVC.Filter;
using BookingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookingMVC.Controllers
{
    [AuthUserFilter]
    public class HabitacionController : Controller
    {
        HabitacionesBusiness habitacionesBusiness = new HabitacionesBusiness();

        public ActionResult Index(string hotelCodigo)
        {
            var habitaciones = new List<Habitacion>();
            habitaciones = habitacionesBusiness.ListarHabitaciones().Where(x => x.Activo).ToList();

            if (string.IsNullOrWhiteSpace(hotelCodigo))
                return View(habitaciones);
            else
                habitaciones = habitaciones.Where(x => x.CodigoHotel == hotelCodigo).ToList();

            return View(habitaciones);
        }

        public ActionResult Detalle(int id)
        {
            var habitacion = habitacionesBusiness.ObtenerHabitacion(id);
            var detalle = new HabitacionDetalle();
            detalle.Habitacion = habitacion;

            return View(detalle);
        }

        [HttpPost]
        public ActionResult Detalle(HabitacionDetalle detalle)
        {
            if (!ModelState.IsValid)
            {
                return View(detalle);
            }
            else {
                Session["Detalle"] = detalle;
                return RedirectToAction("Pago", new { habitacionId = detalle.Habitacion.HabitacionId });
            }
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
            TempData["MostrarPago"] = true;
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
                            var detalle = Session["Detalle"] as HabitacionDetalle;
                            var miembro = Session["Miembro"] as Miembro;
                            DateTime checkin =  DateTime.ParseExact(detalle.CheckIn, "dd/MM/yyyy", null);
                            DateTime checkOut = DateTime.ParseExact(detalle.CheckOut, "dd/MM/yyyy", null);
                            habitacionesBusiness.ReservarHabitacion(habitacion.HabitacionId,
                                miembro.Dni,
                                detalle.Habitacion.CodigoHotel,
                                detalle.Habitacion.CodigoHabitacion,
                                detalle.Habitacion.Numero,
                                detalle.Habitacion.Precio,
                                detalle.Habitacion.CantidadCamas,
                                checkin,
                                checkOut);
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