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
        Miembro ObtenerMiembro(string dni);
        
        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        Miembro CrearMiembro(Miembro miembro);

        [OperationContract]
        Miembro ModificarMiembro(Miembro miembro);

        [OperationContract]
        void EliminarMiembro(string dni);

        [OperationContract]
        List<Miembro> ListarMiembros();
    }
}