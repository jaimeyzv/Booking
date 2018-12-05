using RoomService.Dominio;
using RoomService.Errores;
using System.Collections.Generic;
using System.ServiceModel;

namespace RoomService
{
    [ServiceContract]
    public interface IHabitacionesService
    {
        [OperationContract]
        Habitacion ObtenerHabitacion(int habitacionId);

        [OperationContract]
        Habitacion ObtenerHabitacionPorCodigo(string codigo);

        [OperationContract]
        Habitacion ObtenerPorHotelYNumeroHabitacion(string codigoHotel, int numeroHabitacion);

        [OperationContract]
        [FaultContract(typeof(RepetidoException))]
        Habitacion CrearHabitacion(Habitacion habitacion);

        [OperationContract]
        Habitacion ModificarHabitacion(Habitacion habitacion);

        [OperationContract]
        int EliminarHabitacion(int habitacionId);

        [OperationContract]
        List<Habitacion> ListarHabitaciones();

        [OperationContract]
        List<Habitacion> ListarHabitacionesPorHotel(string codigoHotel);
    }
}