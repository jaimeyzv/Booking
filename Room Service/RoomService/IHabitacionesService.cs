using System.Collections.Generic;
using System.ServiceModel;
using RoomService.Dominio;
using RoomService.Errores;

namespace RoomService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IHabitacionesService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IHabitacionesService
    {
        [OperationContract]
        void DoWork();
    }
}
