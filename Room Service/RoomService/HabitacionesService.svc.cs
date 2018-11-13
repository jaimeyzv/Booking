using System.Collections.Generic;
using System.ServiceModel;
using RoomService.Dominio;
using RoomService.Errores;
using RoomService.Persistencia;

namespace RoomService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "HabitacionesService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione HabitacionesService.svc o HabitacionesService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class HabitacionesService : IHabitacionesService
    {
        private HabitacionDAO dao = new HabitacionDAO();

        public Habitacion ObtenerHabitacion(int numero)
        {
            if (int.Equals(numero, 0))
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "Habitación no válida"
                    }, new FaultReason("Error al obtener Habitación"));
            }
            return dao.Obtener(numero);
        }
        public Habitacion CrearHabitacion(Habitacion habitacion)
        {
            if (dao.Obtener(habitacion.numero) != null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "102",
                        Descripcion = "La habitación ya existe"
                    }, new FaultReason("Error al crear Habitación"));

            return dao.Crear(habitacion);
        }
        public Habitacion ModificarHabitacion(Habitacion habitacion)
        {
            var hab = dao.Obtener(habitacion.numero);
            if (hab == null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "103",
                        Descripcion = "No se encuentra habitación con dicho número"
                    }, new FaultReason("Error al modificar Habitación"));

            return dao.Modificar(habitacion);
        }
        public void EliminarHabitacion(int numero)
        {
            var hab = dao.Obtener(numero);
            if (hab == null)
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "104",
                        Descripcion = "No se encuentra habitación con dicho número"
                    }, new FaultReason("Error al modificar Habitación"));

            dao.Eliminar(numero);
        }
        public List<Habitacion> ListarHabitaciones()
        {
            return dao.Listar();
        }
    }
}
