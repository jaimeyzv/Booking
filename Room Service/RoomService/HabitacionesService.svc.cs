using RoomService.Dominio;
using RoomService.Errores;
using RoomService.Persistencia;
using System.Collections.Generic;
using System.ServiceModel;

namespace RoomService
{
    public class HabitacionesService : IHabitacionesService
    {
        private HabitacionDAO dao = new HabitacionDAO();

        public Habitacion ObtenerHabitacion(int habitacionId)
        {
            if (habitacionId <=0)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Id ingresado no es válido."
                    }, new FaultReason("Error al obtener Habitación."));
            }
            return dao.Obtener(habitacionId);
        }

        public Habitacion ObtenerPorHotelYNumeroHabitacion(string codigoHotel, int numeroHabitacion)
        {
            if (string.IsNullOrWhiteSpace(codigoHotel) || numeroHabitacion <= 0)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "Código de habitación y/o número de habitación son inválidos."
                    }, new FaultReason("Error al obtener Habitación."));
            }
            return dao.ObtenerPorHotelYNumeroHabitacion(codigoHotel, numeroHabitacion);
        }

        public Habitacion CrearHabitacion(Habitacion habitacion)
        {
            if (dao.ObtenerPorHotelYNumeroHabitacion(habitacion.CodigoHotel, habitacion.Numero) != null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "El número de habitación ya existe para el hotel asociado."
                    }, new FaultReason("Error al crear habitación."));

            return dao.Crear(habitacion);
        }
        
        public Habitacion ModificarHabitacion(Habitacion habitacion)
        {
            if (dao.Obtener(habitacion.HabitacionId) == null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "103",
                        Descripcion = "Habitación a modificar no existe."
                    }, new FaultReason("Error al modificar habitación."));

            return dao.Modificar(habitacion);
        }

        public int EliminarHabitacion(int habitacionId)
        {
            var hab = dao.Obtener(habitacionId);
            if (hab == null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "104",
                        Descripcion = "Habitación a eliminar no existe."
                    }, new FaultReason("Error al eliminar habitación."));

            return dao.Eliminar(habitacionId);
        }

        public List<Habitacion> ListarHabitaciones()
        {
            return dao.Listar();
        }
    }
}