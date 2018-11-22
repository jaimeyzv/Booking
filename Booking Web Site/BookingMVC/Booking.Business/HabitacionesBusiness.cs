using Booking.Business.RoomService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Business
{
    public class HabitacionesBusiness
    {
        public List<Habitacion> ListarHabitaciones()
        {
            var habitacionesServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:84/HabitacionesService.svc");
            using (var habitacionesService = new HabitacionesServiceClient(new System.ServiceModel.BasicHttpBinding(), habitacionesServiceRemoteAddress))
            {
                habitacionesService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                return habitacionesService.ListarHabitaciones().ToList();
            }
        }
    }
}