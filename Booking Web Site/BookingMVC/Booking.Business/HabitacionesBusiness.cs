using Booking.Business.BookService;
using Booking.Business.QueueService;
using Booking.Business.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Booking.Business
{
    public class HabitacionesBusiness
    {
        ReservaBusiness reservaBusiness = new ReservaBusiness();

        public List<Habitacion> ListarHabitaciones()
        {
            var habitaciones = new List<Habitacion>();
            var habitacioneIds = new List<string>();
            var hotelIds = new List<string>();
            //var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:61476/HabitacionesService.svc");
            var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:84/HabitacionesService.svc");
            using (var habitacionesService = new HabitacionesServiceClient(new System.ServiceModel.BasicHttpBinding(), habitacionesServiceRemoteAddress))
            {
                habitacionesService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitaciones = habitacionesService.ListarHabitaciones().ToList().ToList();
            }

            //var colasServiceRemoteAddress = new EndpointAddress("http://localhost:40641/ColasService.svc");
            var colasServiceRemoteAddress = new EndpointAddress("http://localhost:92/ColasService.svc");
            using (var colasService = new ColasServiceClient(new System.ServiceModel.BasicHttpBinding(), colasServiceRemoteAddress))
            {
                colasService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitacioneIds = colasService.ListarHabitacionesEnLimpieza().ToList();
                hotelIds = colasService.ListarHotelesNoValidados().ToList();
            }

            var habitacionesHabilitadas = habitaciones.Where(x => !habitacioneIds.Any(z => z == x.CodigoHabitacion)).ToList();
            habitacionesHabilitadas = habitacionesHabilitadas.Where(x => !hotelIds.Any(z => z == x.CodigoHotel)).ToList();
            return habitacionesHabilitadas;
        }

        public List<Habitacion> ListarHabitacionesPorRangoFecha(DateTime inicio, DateTime fin, int camas)
        {
            var habitacionesHabilitadas = new List<Habitacion>();
            var habitacionesReservada = new List<Reserva>();
            var habitaciones = new List<Habitacion>();
            var habitacioneIds = new List<string>();
            var hotelIds = new List<string>();
            var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:84/HabitacionesService.svc");
            using (var habitacionesService = new HabitacionesServiceClient(new System.ServiceModel.BasicHttpBinding(), habitacionesServiceRemoteAddress))
            {
                habitacionesService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitaciones = habitacionesService.ListarHabitaciones().ToList().ToList();
            }

            var colasServiceRemoteAddress = new EndpointAddress("http://localhost:92/ColasService.svc");
            using (var colasService = new ColasServiceClient(new System.ServiceModel.BasicHttpBinding(), colasServiceRemoteAddress))
            {
                colasService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitacioneIds = colasService.ListarHabitacionesEnLimpieza().ToList();
                hotelIds = colasService.ListarHotelesNoValidados().ToList();
            }
            
            habitacionesReservada = reservaBusiness.ListarReservas();
            habitacionesHabilitadas = habitaciones;

            foreach (var reserva in habitacionesReservada)
            {
                if ((fin >= reserva.FechaCheckIn && fin <= reserva.FechaCheckOut)
                    || (inicio >= reserva.FechaCheckIn && inicio <= reserva.FechaCheckOut)
                    || (inicio <= reserva.FechaCheckIn && fin >= reserva.FechaCheckOut))
                {
                    var hab = habitacionesHabilitadas.Where(x => x.CodigoHabitacion == reserva.CodigoHabitacion).FirstOrDefault();
                    if (hab != null)
                    {
                        habitacionesHabilitadas.Remove(hab);
                    }
                }
            }

            habitacionesHabilitadas = habitacionesHabilitadas.Where(x => x.CantidadCamas == camas).ToList();
            habitacionesHabilitadas = habitacionesHabilitadas.Where(x => !habitacioneIds.Any(z => z == x.CodigoHabitacion)).ToList();
            habitacionesHabilitadas = habitacionesHabilitadas.Where(x => !hotelIds.Any(z => z == x.CodigoHotel)).ToList();
            return habitacionesHabilitadas;
        }

        public Habitacion ObtenerHabitacion(int id)
        {
            var habitacion = new Habitacion();
            var habitacionesIds = new List<string>();
            //var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:61476/HabitacionesService.svc");
            var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:84/HabitacionesService.svc");
            using (var habitacionesService = new HabitacionesServiceClient(new System.ServiceModel.BasicHttpBinding(), habitacionesServiceRemoteAddress))
            {
                habitacionesService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitacion = habitacionesService.ObtenerHabitacion(id);
            }

            if (habitacion == null)
                return habitacion;

            //var colasServiceRemoteAddress = new EndpointAddress("http://localhost:40641/ColasService.svc");
            var colasServiceRemoteAddress = new EndpointAddress("http://localhost:92/ColasService.svc");
            using (var colasService = new ColasServiceClient(new System.ServiceModel.BasicHttpBinding(), colasServiceRemoteAddress))
            {
                colasService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitacionesIds = colasService.ListarHabitacionesEnLimpieza().ToList();
            }

            var habilitado = !habitacionesIds.Any(x => x == habitacion.CodigoHabitacion);

            if (habilitado)
                return habitacion;
            return null;
        }

        public void ReservarHabitacion(int id, string dni, string codigoHotel, string codigoHabitacion, int numero, decimal precio,int cantidad, DateTime checkIn, DateTime checkOut)
        {
            var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:84/HabitacionesService.svc");
            using (var habitacionesService = new HabitacionesServiceClient(new System.ServiceModel.BasicHttpBinding(), habitacionesServiceRemoteAddress))
            {
                habitacionesService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                var habitacion = habitacionesService.ObtenerHabitacion(id);
                habitacion.Activo = false;
                habitacionesService.ModificarHabitacion(habitacion);
            }

            var reservasServiceRemoteAddress = new EndpointAddress("http://localhost:86/ReservaService.svc");
            using (var reservasService = new ReservaServiceClient(new System.ServiceModel.BasicHttpBinding(), reservasServiceRemoteAddress))
            {
                reservasService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                var reserva = new Reserva();
                reserva.Codigo = DateTime.Now.ToString("dd-MM-yyyy-HH-ss") + "-" + dni;
                reserva.DniMiembro = dni;
                reserva.CodigoHotel = codigoHotel;
                reserva.CodigoHabitacion = codigoHabitacion;
                reserva.NumeroHabitacion = numero;
                reserva.PrecioHotel = precio;
                reserva.CantidadPersonas = cantidad;
                reserva.FechaCheckIn = checkIn;
                reserva.FechaCheckOut = checkOut;
                reserva.FechaRegistro = DateTime.Now;
                reserva.Estado = "RESERVADO";

                reservasService.RealizarReserva(reserva);
            }
        }
    }
}