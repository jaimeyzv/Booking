using System.Collections.Generic;
using System.ServiceModel;
using WcfHotel.Dominio;
using WcfHotel.Errores;

namespace WcfHotel
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IHotelService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IHotelService
    {

        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        Hotel CrearHotel(Hotel hotel);

        [OperationContract]
        Hotel ConsultarHotel(string nombre);

        [OperationContract]
        Hotel ModificarHotel(Hotel hotel);

        [OperationContract]
        void EliminarHotel(int idHotel);

        [OperationContract]
        List<Hotel> ListarHoteles();


    }
}
