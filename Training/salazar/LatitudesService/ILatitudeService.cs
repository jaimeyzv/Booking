using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static LatitudesService.LatitudeService;

namespace LatitudesService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILatitudeService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ILatitudeService
    {
        [OperationContract]
        Coordenadas obtenerCoordenadas();

    }
}
