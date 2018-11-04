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

            var objeto = obtenerCoordenada();
            return string.Format("La temperatura en " + ciudad + " es de " + obtenerTemperatura() + " grados " +
                "con Long: " + objeto.GetValue(0) + " y Lat: " + objeto.GetValue(1));
        }

        public int obtenerTemperatura()
        {
            TempWS.TemperaturaServiceClient proxy = new TempWS.TemperaturaServiceClient();
            return proxy.ObtenerTemperatura();
        }

        public object[] obtenerCoordenada()
        {
            LatWS.LatitudeServiceClient proxy = new LatWS.LatitudeServiceClient();
            var obj = proxy.obtenerCoordenadas();
            object[] objReturn = new object[2];
            objReturn.SetValue(obj.coordenadaX, 0);
            objReturn.SetValue(obj.coordenadaY, 1);
            return objReturn;
        }
    }
}
