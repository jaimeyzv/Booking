using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LatitudesService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "LatitudeService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione LatitudeService.svc o LatitudeService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class LatitudeService : ILatitudeService
    {
        public Coordenadas obtenerCoordenadas()
        {
            Coordenadas[] obj = new Coordenadas[1];
            obj[0] = new Coordenadas { coordenadaX = "-45.05", coordenadaY = "24.7089" };
            return obj[0];
        }

        public class Coordenadas
        {
            public string coordenadaX;
            public string coordenadaY;
        }
    }
}
