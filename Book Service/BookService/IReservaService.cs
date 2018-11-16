using BookService.Dominio;
using System.Collections.Generic;
using System.ServiceModel;

namespace BookService
{
    [ServiceContract]
    public interface IReservaService
    {
        [OperationContract]
        Reserva RealizarReserva(Reserva reserva);

        [OperationContract]
        Reserva ModificarReserva(Reserva reserva);

        [OperationContract]
        Reserva CancelarReserva(int reservaId);

        [OperationContract]
        List<Reserva> ListarReservasPorMiembro(string dni);
    }
}