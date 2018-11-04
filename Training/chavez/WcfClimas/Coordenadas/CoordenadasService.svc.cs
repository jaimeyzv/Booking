using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfClimas.Coordenadas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CoordenadasService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CoordenadasService.svc o CoordenadasService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CoordenadasService : ICoordenadasService
    {
        public string ObtenerCoordenadas()
        {
            Random random = new Random();
            string coordenada = random.Next(-90, 90) + " ° . " + random.Next(0, 60) + " m. " + random.Next(0, 60) +
                " s" + " " + random.Next(-180, 180) + " ° . " + random.Next(0, 60) + " m. " + random.Next(0, 60) + " s";

            return coordenada;
        }
    }
}
