using Booking.Business.MemberService;
using Booking.Business.ReniecService;
using BookingModels;
using System;

namespace Booking.Business
{
    public class RegistroBusiness
    {
        public bool RegistrarMiembro(Registro registro)
        {
            try
            {
                var miembrosServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:82/MiembrosService.svc");
                using (var miembrosService = new MiembrosServiceClient(new System.ServiceModel.BasicHttpBinding(), miembrosServiceRemoteAddress))
                {
                    var miembro = new Miembro()
                    {
                        Nombres = registro.Nombres,
                        ApellidoPaterno = registro.ApellidoPaterno,
                        ApellidoMaterno = registro.ApellidoMaterno,
                        Dni = registro.Dni,
                        Edad = registro.Edad,
                        Correo = registro.Correo,
                        Password = registro.Contrasena
                    };

                    miembrosService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                    var memeber = miembrosService.CrearMiembro(miembro);
                }

                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool ExisteDni(string dni)
        {
            var miembrosServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:82/MiembrosService.svc");
            using (var miembrosService = new MiembrosServiceClient(new System.ServiceModel.BasicHttpBinding(), miembrosServiceRemoteAddress))
            {
                miembrosService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                return miembrosService.ObtenerMiembro(dni) != null;
            }
        }

        public bool EsDniValido(string dni)
        {
            try
            {
                var reniecServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:83/ReniecService.svc");
                using (var reniecService = new ReniecServiceClient(new System.ServiceModel.BasicHttpBinding(), reniecServiceRemoteAddress))
                {
                    reniecService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                    return reniecService.EsDniValido(dni);
                }
            }
            catch (Exception ex){ return false; }
        }

        public void EnviarCorreoBienvenida(string correo, string nombre)
        {
            var notificatorServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:90/NotificacionService.svc");
            using (var notificatorService = new NotificatorService.NotificacionServiceClient(new System.ServiceModel.BasicHttpBinding(), notificatorServiceRemoteAddress))
            {
                notificatorService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                notificatorService.EnviaCorreo(correo, nombre);
            }
        }
    }
}