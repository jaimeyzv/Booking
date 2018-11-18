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
                CodigoHabitacion = "HT00999999",
                CodigoHotel = "HBT0009999",
                Descripcion = "Habitación matrimonial",
                Precio = 111,
                Numero = 101,
                CantidadCamas = 1,
                Codigoimagen = "HT00999999.jpg"
            });
            
            Assert.AreEqual("HT00999999", nuevaHabitacion.CodigoHabitacion);
            Assert.AreEqual("HBT0009999", nuevaHabitacion.CodigoHotel);
            Assert.AreEqual("Habitación matrimonial", nuevaHabitacion.Descripcion);
            Assert.AreEqual(111, nuevaHabitacion.Precio);
            Assert.AreEqual(101, nuevaHabitacion.Numero);
            Assert.AreEqual(1, nuevaHabitacion.CantidadCamas);
            Assert.AreEqual("HT00999999.jpg", nuevaHabitacion.Codigoimagen);

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
                    CodigoHabitacion = "HT00999999",
                    CodigoHotel = codigoHotel,
                    Descripcion = "Habitación matrimonial",
                    Precio = 111,
                    Numero = numeroHabitacion,
                    CantidadCamas = 1,
                    Codigoimagen = "HT00999999.jpg"
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
                CodigoHabitacion = "HT00999999",
                CodigoHotel = codigoHotel,
                Descripcion = "Habitación matrimonial",
                Precio = 111,
                Numero = numeroHabitacion,
                CantidadCamas = 1,
                Codigoimagen = "HT00999999.jpg"
            });
        }

        private static HabitacionesWS.Habitacion ObtenerHabitacionPorCodigoHotelYNumeroHabitacionParaPruebas(string codigoHotel, int numeroHabitacion)
        {
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();
            return proxy.ObtenerPorHotelYNumeroHabitacion(codigoHotel, numeroHabitacion);
        }
    }
}