using BookService.Dominio;
using BookService.Errores;
using BookService.Persistencia;
using System.Collections.Generic;
using System.ServiceModel;

namespace BookService
{
    public class ReservaService : IReservaService
    {
        ReservaDAO dao = new ReservaDAO();

        public Reserva CancelarReserva(int reservaId)
        {
            if (reservaId <= 0)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Id ingresado no es válido."
                    }, new FaultReason("Error al cancelar reserva."));
            }

            var reserva = dao.Obtener(reservaId);
            reserva.Estado = "CANCELADO";
            return dao.Modificar(reserva);
        }
        
        public List<Reserva> ListarReservasPorMiembro(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "Dni ingresado no es válido."
                    }, new FaultReason("Error al listar reserva."));
            }

            return dao.ListarPorMiembro(dni);
        }

        public Reserva ModificarReserva(Reserva reserva)
        {
            return dao.Modificar(reserva);
        }

        public Reserva RealizarReserva(Reserva reserva)
        {
            return dao.Crear(reserva);
        }
    }
}