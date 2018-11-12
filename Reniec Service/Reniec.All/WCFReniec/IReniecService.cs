using System.ServiceModel;
using WCFReniec.Dominio;

namespace WCFReniec
{
    [ServiceContract]
    public interface IReniecService
    {
        [OperationContract]
        bool EsDniValido(string dni);

        [OperationContract]
        Persona ObtenerPersonaPorDni(string dni);
    }
}