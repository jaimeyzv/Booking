using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TemperaturasService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTemperatura" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTemperatura.svc o ServiceTemperatura.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTemperatura : IServiceTemperatura
    {
        

        public int Temperatura()
        {
            Random rdn = new Random();
            int temp = rdn.Next(1, 99);
            return temp;
        }
    }
}
