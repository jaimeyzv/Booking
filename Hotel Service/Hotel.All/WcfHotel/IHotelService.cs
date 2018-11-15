using System.Collections.Generic;
using System.ServiceModel;
using WcfHotel.Dominio;
using WcfHotel.Errores;

namespace WcfHotel
{
    [ServiceContract]
    public interface IHotelService
    {

        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        Hotels CrearHotel(Hotels hotel);

        [OperationContract]
        Hotels ObtenerHotelPorCodigo(string codigo);

        [OperationContract]
        Hotels ModificarHotel(Hotels hotel);

        [OperationContract]
        int EliminarHotel(string codigo);

        [OperationContract]
        List<Hotels> ListarHoteles();
    }
}