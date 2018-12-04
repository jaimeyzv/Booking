using Booking.Business.HotelService;
using Booking.Business.QueueService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Booking.Business
{
    public class HotelesBusiness
    {
        public List<Hotels> ListarHoteles()
        {
            var hoteles = new List<Hotels>();
            var hotelesIds = new List<string>();
            //var hotelesServiceRemoteAddress = new EndpointAddress("http://localhost:53745/HotelService.svc");
            var hotelesServiceRemoteAddress = new EndpointAddress("http://localhost:85/HotelService.svc");
            using (var hotelService = new HotelServiceClient(new System.ServiceModel.BasicHttpBinding(), hotelesServiceRemoteAddress))
            {
                hotelService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                hoteles = hotelService.ListarHoteles().ToList();
            }

            //var colasServiceRemoteAddress = new EndpointAddress("http://localhost:40641/ColasService.svc");
            var colasServiceRemoteAddress = new EndpointAddress("http://localhost:92/ColasService.svc");
            using (var colasService = new ColasServiceClient(new System.ServiceModel.BasicHttpBinding(), colasServiceRemoteAddress))
            {
                colasService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                hotelesIds = colasService.ListarHotelesNoValidados().ToList();
            }

            var habitacionesHabilitadas = hoteles.Where(x => !hotelesIds.Any(z => z == x.Codigo)).ToList();
            return habitacionesHabilitadas;
        }
    }
}