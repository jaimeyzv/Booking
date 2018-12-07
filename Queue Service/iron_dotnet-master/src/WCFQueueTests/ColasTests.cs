using IronSharp.Core;
using IronSharp.IronMQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace WCFQueueTests
{
    [TestClass]
    public class ColasTests
    {
        [TestMethod]
        public void ListarHabitacionesEnLimpieza_CuandoHayColaYMensajes_RetornaListaMensajes()
        {
            CrearCola3MensajeHabitacion();
            ColasWS.ColasServiceClient proxy = new ColasWS.ColasServiceClient();
            var colaHabitacion = proxy.ListarHabitacionesEnLimpieza().ToList();

            Assert.IsTrue(colaHabitacion.Any());
            //Assert.IsTrue(colaHabitacion.Count >= 3);

            ClearMessagesHabitacion();
        }

        [TestMethod]
        public void ListarHotelesNoValidados_CuandoHayColaYMensajes_RetornaListaMensajes()
        {
            CrearCola3MensajeHotel();
            ColasWS.ColasServiceClient proxy = new ColasWS.ColasServiceClient();
            var colaHotel = proxy.ListarHotelesNoValidados().ToList();

            Assert.IsTrue(colaHotel.Any());
            //Assert.IsTrue(colaHotel.Count >= 3);

            ClearMessagesHotel();
        }

        private static void CrearCola3MensajeHabitacion()
        {
            IronMqRestClient ironMq = Client.New(new IronClientConfig { ProjectId = "5bf768af967e0f000910fed3", Token = "y7TU7c3D3IUXtwrcJJFH", Host = "mq-aws-eu-west-1-1.iron.io", ApiVersion = 3, Scheme = Uri.UriSchemeHttp });
            QueueClient queueHabitacion = ironMq.Queue("Habitacion");
            var codigoHabitacion1 = "HBT0000001";
            queueHabitacion.Post(codigoHabitacion1);
            var codigoHabitacion2 = "HBT0000002";
            queueHabitacion.Post(codigoHabitacion2);
            var codigoHabitacion3 = "HBT0000003";
            queueHabitacion.Post(codigoHabitacion3);
        }

        private static void ClearMessagesHabitacion()
        {
            IronMqRestClient ironMq = Client.New(new IronClientConfig { ProjectId = "5bf768af967e0f000910fed3", Token = "y7TU7c3D3IUXtwrcJJFH", Host = "mq-aws-eu-west-1-1.iron.io", ApiVersion = 3, Scheme = Uri.UriSchemeHttp });
            QueueClient queueHabitacion = ironMq.Queue("Habitacion");
            queueHabitacion.Clear();
        }

        private static void CrearCola3MensajeHotel()
        {
            IronMqRestClient ironMq = Client.New(new IronClientConfig { ProjectId = "5bf768af967e0f000910fed3", Token = "y7TU7c3D3IUXtwrcJJFH", Host = "mq-aws-eu-west-1-1.iron.io", ApiVersion = 3, Scheme = Uri.UriSchemeHttp });
            QueueClient queueHabitacion = ironMq.Queue("Hotel");
            var codigoHotel1 = "HT00000001";
            queueHabitacion.Post(codigoHotel1);
            var codigoHotel2 = "HT00000002";
            queueHabitacion.Post(codigoHotel2);
            var codigoHotel3 = "HT00000003";
            queueHabitacion.Post(codigoHotel3);
        }

        private static void ClearMessagesHotel()
        {
            IronMqRestClient ironMq = Client.New(new IronClientConfig { ProjectId = "5bf768af967e0f000910fed3", Token = "y7TU7c3D3IUXtwrcJJFH", Host = "mq-aws-eu-west-1-1.iron.io", ApiVersion = 3, Scheme = Uri.UriSchemeHttp });
            QueueClient queueHabitacion = ironMq.Queue("Hotel");
            queueHabitacion.Clear();
        }
    }
}