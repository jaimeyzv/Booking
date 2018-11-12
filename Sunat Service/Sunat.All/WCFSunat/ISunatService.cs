using System.ServiceModel;
using WCFSunat.Dominio;

namespace WCFSunat
{
    [ServiceContract]
    public interface ISunatService
    {
        [OperationContract]
        bool EsDniValido(string dni);

        [OperationContract]
        Persona ObtenerPersonaPorDni(string dni);
    }
}