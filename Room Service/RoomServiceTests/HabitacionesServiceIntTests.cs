using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace RoomServiceTests
{
    [TestClass]
    public class HabitacionesServiceIntTests
    {
        [TestMethod]
        public void CrearHabitacion_CuandoNuevaHabitacionEsValida_RetornaNuevaHabitacionCreada()
        {
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();

            var nuevaHabitacion = proxy.CrearHabitacion(new HabitacionesWS.Habitacion
            {
                CodigoHotel = "HT99999999",
                Descripcion = "Habitación matrimonial",
                Numero = 201,
                CantidadCamas = 1,
            });

            Assert.AreEqual("HT99999999", nuevaHabitacion.CodigoHotel);
            Assert.AreEqual("Habitación matrimonial", nuevaHabitacion.Descripcion);
            Assert.AreEqual(201, nuevaHabitacion.Numero);
            Assert.AreEqual(1, nuevaHabitacion.CantidadCamas);

            EliminarHabitacionParaPruebas(nuevaHabitacion.HabitacionId);
        }

        [TestMethod]
        public void CrearHabitacion_CuandoElCodigoDeHotelYNumeroHabitacionYaExisten_RetornaRepetidoException()
        {
            var codigoHotel = "HTXXX00001";
            var numeroHabitacion = 999;
            CrearHabitacionParaPruebas(codigoHotel, numeroHabitacion);
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();

            try
            {
                proxy.CrearHabitacion(new HabitacionesWS.Habitacion
                {
                    CodigoHotel = codigoHotel,
                    Descripcion = "Habitación matrimonial",
                    Numero = numeroHabitacion,
                    CantidadCamas = 1,
                });
            }
            catch (FaultException<HabitacionesWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al crear habitación.", error.Reason.ToString());
                Assert.AreEqual("102", error.Detail.Codigo);
                Assert.AreEqual("El número de habitación ya existe para el hotel asociado.", error.Detail.Descripcion);
            }

            var habitacion = ObtenerHabitacionPorCodigoHotelYNumeroHabitacionParaPruebas(codigoHotel, numeroHabitacion);
            EliminarHabitacionParaPruebas(habitacion.HabitacionId);
        }
        
        private static void EliminarHabitacionParaPruebas(int habitacionId)
        {
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();
            proxy.EliminarHabitacion(habitacionId);
        }

        private static HabitacionesWS.Habitacion CrearHabitacionParaPruebas(string codigoHotel, int numeroHabitacion)
        {
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();
            return proxy.CrearHabitacion(new HabitacionesWS.Habitacion
            {
                CodigoHotel = codigoHotel,
                Descripcion = "Habitación matrimonial",
                Numero = numeroHabitacion,
                CantidadCamas = 2,
            });
        }

        private static HabitacionesWS.Habitacion ObtenerHabitacionPorCodigoHotelYNumeroHabitacionParaPruebas(string codigoHotel, int numeroHabitacion)
        {
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();
            return proxy.ObtenerPorHotelYNumeroHabitacion(codigoHotel, numeroHabitacion);
        }
    }
}