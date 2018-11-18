using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WFCMiembros.Dominio;

namespace WFCMiembros
{
    [ServiceContract]
    public interface IMiembroServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Miembros/{dni}", ResponseFormat = WebMessageFormat.Json)]
        Miembro ObtenerMiembro(string dni);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Miembros", ResponseFormat = WebMessageFormat.Json)]
        Miembro CrearMiembro(Miembro miembro);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Miembros", ResponseFormat = WebMessageFormat.Json)]
        Miembro ModificarMiembro(Miembro miembro);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Miembros/{dni}", ResponseFormat = WebMessageFormat.Json)]
        int EliminarMiembro(string dni);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Miembros", ResponseFormat = WebMessageFormat.Json)]
        List<Miembro> ListarMiembros();
    }
}