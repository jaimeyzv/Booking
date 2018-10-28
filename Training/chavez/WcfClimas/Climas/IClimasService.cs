using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfClimas.Climas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClimasService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClimasService
    {
        [OperationContract]
        string ConsultarClima(int zip);
    }
}
