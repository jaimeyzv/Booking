using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using MobilityService.Dominio;

namespace MobilityService
{
    [ServiceContract]
    public interface IMobilityServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Movilidades/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Movilidad ObtenerMovilidad(string codigo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Movilidades", ResponseFormat = WebMessageFormat.Json)]
        Movilidad CrearMovilidad(Movilidad movilidad);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Movilidades", ResponseFormat = WebMessageFormat.Json)]
        Movilidad ModificarMovilidad(Movilidad movilidad);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Movilidades/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        int EliminarMovilidad(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Movilidades", ResponseFormat = WebMessageFormat.Json)]
        List<Movilidad> ListarMovilidades();
    }
}
