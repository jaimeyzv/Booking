using Booking.Business.MemberService;
using System;

namespace Booking.Business
{
    public class AutenticacionBusiness
    {
        public Miembro IniciarSesion(string dni, string contrasena)
        {
            //var miembrosServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:25703/MiembrosService.svc");
            var miembrosServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:82/MiembrosService.svc");
            using (var miembrosService = new MiembrosServiceClient(new System.ServiceModel.BasicHttpBinding(), miembrosServiceRemoteAddress))
            {
                miembrosService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                return miembrosService.IniciarSesion(dni, contrasena);
            }
        }
    }
}