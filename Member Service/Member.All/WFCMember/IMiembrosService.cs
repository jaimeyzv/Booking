using System.Collections.Generic;
using System.ServiceModel;
using WCFMember.Dominio;
using WCFMember.Errores;

namespace WFCMember
{
    [ServiceContract]
    public interface IMiembrosService
    {
        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        [ServiceKnownType(typeof(RepetidoException))]
        Miembro ObtenerMiembro(string dni);
        
        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        [ServiceKnownType(typeof(RepetidoException))]
        Miembro CrearMiembro(Miembro miembro);

        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        [ServiceKnownType(typeof(RepetidoException))]
        Miembro ModificarMiembro(Miembro miembro);

        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        [ServiceKnownType(typeof(RepetidoException))]
        void EliminarMiembro(string dni);

        [OperationContract]
        List<Miembro> ListarMiembros();
    }
}