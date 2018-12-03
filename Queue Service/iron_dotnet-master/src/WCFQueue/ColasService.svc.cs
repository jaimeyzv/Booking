using IronSharp.Core;
using IronSharp.IronMQ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WCFQueue
{
    public class ColasService : IColasService
    {
        public List<string> ListarHabitacionesEnLimpieza()
        {
            IronMqRestClient ironMq = Client.New(new IronClientConfig { ProjectId = "5bf768af967e0f000910fed3", Token = "y7TU7c3D3IUXtwrcJJFH", Host = "mq-aws-eu-west-1-1.iron.io", ApiVersion = 3, Scheme = Uri.UriSchemeHttp });
            QueueClient queueHabitacion = ironMq.Queue("Habitacion");

            bool finished = false;
            var habitacionIds = new List<string>();

            while (!finished)
            {
                var messageHotel = queueHabitacion.Reserve();
                if (messageHotel != null)
                    habitacionIds.Add(messageHotel.Body);
                else
                    finished = true;
            }

            return habitacionIds.Select(x => x).Distinct().ToList();
        }

        public List<string> ListarHotelesNoValidados()
        {
            IronMqRestClient ironMq = Client.New(new IronClientConfig { ProjectId = "5bf768af967e0f000910fed3", Token = "y7TU7c3D3IUXtwrcJJFH", Host = "mq-aws-eu-west-1-1.iron.io", ApiVersion = 3, Scheme = Uri.UriSchemeHttp });
            QueueClient queueHotel = ironMq.Queue("Hotel");

            bool finished = false;
            var hotelIds = new List<string>();

            while (!finished)
            {
                var messageHotel = queueHotel.Reserve();
                if (messageHotel != null)
                    hotelIds.Add(messageHotel.Body);
                else
                    finished = true;
            }

            return hotelIds.Select(x => x).Distinct().ToList();
        }
    }
}