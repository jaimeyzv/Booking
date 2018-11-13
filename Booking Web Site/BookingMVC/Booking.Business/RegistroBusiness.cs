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
                var reniecServiceRemoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:83/ReniecService.svc");
                using (var reniecService = new ReniecServiceClient(new System.ServiceModel.BasicHttpBinding(), reniecServiceRemoteAddress))
                {
                    reniecService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                    if (!reniecService.EsDniValido(registro.Dni))
                        return false;
                }

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
                        Password = registro.contrasena
                    };

                    miembrosService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 20);
                    var memeber = miembrosService.CrearMiembro(miembro);
                }

                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}