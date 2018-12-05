using Booking.Business.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Booking.Business
{
    public class ReservaBusiness
    {
        public List<Reserva> ListarReservas(string dni)
        {
            var hotelesServiceRemoteAddress = new EndpointAddress("http://localhost:86/ReservaService.svc");
            using (var reservaService = new ReservaServiceClient(new System.ServiceModel.BasicHttpBinding(), hotelesServiceRemoteAddress))
            {
                reservaService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                return reservaService.ListarReservasPorMiembro(dni).ToList();
            }
        }
    }
}