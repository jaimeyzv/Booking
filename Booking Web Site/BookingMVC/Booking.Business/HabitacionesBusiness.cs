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
        public List<Habitacion> ListarHabitaciones()
        {
            var habitaciones = new List<Habitacion>();
            var habitacioneIds = new List<string>();
            var hotelIds = new List<string>();
            var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:84/HabitacionesService.svc");
            using (var habitacionesService = new HabitacionesServiceClient(new System.ServiceModel.BasicHttpBinding(), habitacionesServiceRemoteAddress))
            {
                habitacionesService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitaciones = habitacionesService.ListarHabitaciones().ToList();
            }

            var colasServiceRemoteAddress = new EndpointAddress("http://localhost:92/ColasService.svc");
            using (var colasService = new ColasServiceClient(new System.ServiceModel.BasicHttpBinding(), colasServiceRemoteAddress))
            {
                colasService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitacioneIds = colasService.ListarHabitacionesEnLimpieza().ToList();
                hotelIds = colasService.ListarHotelesNoValidados().ToList();
            }

            var habitacionesHabilitadas = habitaciones.Where(x => !habitacioneIds.Any(z => z == x.CodigoHabitacion)).ToList();
            habitacionesHabilitadas = habitaciones.Where(x => !hotelIds.Any(z => z == x.CodigoHotel)).ToList();
            return habitacionesHabilitadas;
        }

        public Habitacion ObtenerHabitacion(int id)
        {
            var habitacion = new Habitacion();
            var habitacionesIds = new List<string>();
            var habitacionesServiceRemoteAddress = new EndpointAddress("http://localhost:84/HabitacionesService.svc");
            using (var habitacionesService = new HabitacionesServiceClient(new System.ServiceModel.BasicHttpBinding(), habitacionesServiceRemoteAddress))
            {
                habitacionesService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                habitacion = habitacionesService.ObtenerHabitacion(id);
            }

            if (habitacion == null)
                return habitacion;

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
    }
}