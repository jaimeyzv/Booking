using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClimasService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceClima" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceClima.svc o ServiceClima.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceClima : IServiceClima
    {
        public string Clima(int zip)
        {
            string ciudad;
            switch (zip)
            {
                case 1: ciudad = "Lima";
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

            var proxy = new ServiceTemp.ServiceTemperaturaClient();
            var proxy2 = new ServiceCoorde.ServiceCoordenadaClient();

            return ciudad + " " + proxy.Temperatura() + "° C  " + proxy2.Coordenada();
                



        }

        
    }
}
