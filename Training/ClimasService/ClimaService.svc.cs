using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClimasService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ClimaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ClimaService.svc o ClimaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ClimaService : IClimaService
    {
        public void DoWork()
        {
        }

        public string ConsultarClima(int zip)
        {
            String ciudad;
            switch (zip)
            {
                case 1:
                    ciudad = "Lima";
                    break;
                case 2:
                    ciudad = "Arequipa";
                    break;
                case 3:
                    ciudad = "Trujillo";
                    break;
                default:
                    ciudad = "Moquegua";
                    break;
            }
            return string.Format("La temperatura en " + ciudad + " es de " + obtenerTemperatura() + " grados");
        }

        public int obtenerTemperatura()
        {
            TempWS.TemperaturaServiceClient proxy = new TempWS.TemperaturaServiceClient();
            return proxy.ObtenerTemperatura();
        }
    }
}
