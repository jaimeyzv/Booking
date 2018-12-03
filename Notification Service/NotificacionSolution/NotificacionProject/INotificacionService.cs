using System.ServiceModel;
using System.ServiceModel.Web;

namespace NotificacionProject
{
    [ServiceContract]
    public interface INotificacionService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Correo/{correo}", ResponseFormat = WebMessageFormat.Json)]
        void EnviaCorreo(string correo, string nombre);
    }
}