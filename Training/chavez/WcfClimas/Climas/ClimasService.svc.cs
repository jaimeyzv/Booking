using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfClimas.Climas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ClimasService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ClimasService.svc o ClimasService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ClimasService : IClimasService
    {
        public string ConsultarClima(int zip)
        {
            var mensaje = string.Empty;

            TemperaturaReference.TemperaturaServiceClient proxy = new TemperaturaReference.TemperaturaServiceClient();
            CoordenadasReference.CoordenadasServiceClient proxy2 = new CoordenadasReference.CoordenadasServiceClient();



            int temp = proxy.ObtenerTemperatura();
            string coord = proxy2.ObtenerCoordenadas();


            switch (zip)
            {
                case 1:
                    mensaje = "Lima " + temp.ToString() + " °C   " + coord;
                    break;

                case 2:
                    mensaje = "Arequipa " + temp.ToString() + " °C   " + coord;
                    break;

                case 3:
                    mensaje = "Trujillo " + temp.ToString() + " °C   " + coord;
                    break;

                default:
                    mensaje = "Moquegua " + temp.ToString() + " °C   " + coord;
                    break;
            }
            return mensaje;
        }
    }
}
