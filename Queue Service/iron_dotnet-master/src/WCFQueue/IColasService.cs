using System.Collections.Generic;
using System.ServiceModel;

namespace WCFQueue
{
    [ServiceContract]
    public interface IColasService
    {
        [OperationContract]
        List<string> ListarHabitacionesEnLimpieza();

        [OperationContract]
        List<string> ListarHotelesNoValidados();
    }
}