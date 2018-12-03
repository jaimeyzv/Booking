using Booking.Business.HotelService;
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
            var hotelesServiceRemoteAddress = new EndpointAddress("http://localhost:85/HotelService.svc");
            using (var hotelService = new HotelServiceClient(new System.ServiceModel.BasicHttpBinding(), hotelesServiceRemoteAddress))
            {
                hotelService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                return hotelService.ListarHoteles().ToList();
            }
        }
    }
}