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
            //var habitaciones = new List<Habitacion>();
            //habitaciones = habitacionesBusiness.ListarHabitaciones().Where(x => x.Activo).ToList();

            //if (string.IsNullOrWhiteSpace(hotelCodigo))
            //    return View(habitaciones);
            //else
            //    habitaciones = habitaciones.Where(x => x.CodigoHotel == hotelCodigo).ToList();

            //return View(habitaciones);

            //DateTime checkin = DateTime.ParseExact(Session["FechaIni"].ToString(), "dd/MM/yyyy", null);
            //DateTime checkOut = DateTime.ParseExact(Session["FechaFin"].ToString(), "dd/MM/yyyy", null);


            if (!string.IsNullOrWhiteSpace(hotelCodigo))
            {
                var habitaciones = new List<Habitacion>();
                //habitaciones = habitacionesBusiness.ListarHabitaciones().Where(x => x.Activo).ToList();
                habitaciones = habitaciones.Where(x => x.CodigoHotel == hotelCodigo).ToList();
                return View(habitaciones);
            }
            else
            {
                //Session["FechaIni"] = "10/12/2018";
                //Session["FechaFin"] = "15/12/2018";
                //Session["Camas"] = "1";

                if (Session["FechaIni"] == null || Session["FechaIni"].ToString() == "")
                {
                    var habitaciones = new List<Habitacion>();
                    //habitaciones = habitacionesBusiness.ListarHabitaciones().Where(x => x.Activo).ToList();
                    habitaciones = habitacionesBusiness.ListarHabitaciones().ToList();
                    return View(habitaciones);
                }
                else {
                    //Session["FechaIni"] = "10/12/2018";
                    //Session["FechaFin"] = "15/12/2018";
                    //Session["Camas"] = "1";

                    DateTime checkin = DateTime.ParseExact(Session["FechaIni"].ToString(), "dd/MM/yyyy", null);
                    DateTime checkOut = DateTime.ParseExact(Session["FechaFin"].ToString(), "dd/MM/yyyy", null);

                    var camas = Convert.ToInt32(Session["Camas"].ToString());

                    var habitaciones = new List<Habitacion>();
                    //habitaciones = habitacionesBusiness.ListarHabitacionesPorRangoFecha(checkin, checkOut, camas).Where(x => x.Activo).ToList();
                    habitaciones = habitacionesBusiness.ListarHabitacionesPorRangoFecha(checkin, checkOut, camas).ToList();

                    return View(habitaciones);
                }
            }
        }

        public ActionResult Detalle(int id)
        {
            var habitacion = habitacionesBusiness.ObtenerHabitacion(id);
            var detalle = new HabitacionDetalle();
            detalle.Habitacion = habitacion;
            detalle.CheckIn = Session["FechaIni"] != null ? Session["FechaIni"].ToString() : string.Empty;
            detalle.CheckOut = Session["FechaFin"] != null ? Session["FechaFin"].ToString() : string.Empty;

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
                DateTime checkin = DateTime.ParseExact(detalle.CheckIn, "dd/MM/yyyy", null);
                DateTime checkOut = DateTime.ParseExact(detalle.CheckOut, "dd/MM/yyyy", null);
                var hoy = DateTime.Today;

                int result1 = DateTime.Compare(hoy, checkin);
                int result2 = DateTime.Compare(hoy, checkOut);
                if (result1 >= 0 || result2 >= 0)
                {
                    TempData["ErrorFecha"] = "Las fechas ingresadas mayor al día de hoy.";
                    return View(detalle);
                }
                

                int result = DateTime.Compare(checkin, checkOut);
                if (result >= 0)
                {
                    TempData["ErrorFecha"] = "Checkout debe ser mayor al checkin.";
                    return View(detalle);
                }

                var dias = (checkOut.Date - checkin.Date).Days;
                if (dias <= 2)
                {
                    TempData["ErrorFecha"] = "La cantidad de días debe ser de 3 a más.";
                    return View(detalle);
                }

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