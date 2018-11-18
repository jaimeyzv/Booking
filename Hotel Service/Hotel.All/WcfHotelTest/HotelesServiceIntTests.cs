using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WcfHotelTest
{
    [TestClass]
    public class HotelesServiceIntTests
    {
        [TestMethod]
        public void CrearHabitacion_CuandoNuevaHabitacionEsValida_RetornaNuevaHabitacionCreada()
        {
            HotelesWS.HotelServiceClient proxy = new HotelesWS.HotelServiceClient();

            var nuevaHotel = proxy.CrearHotel(new HotelesWS.Hotels
            {
                Codigo = "HT99999999",
                Nombre = "El Reencuentro",
                Descripcion = "Hotel más caleta de Lima",
                Direccion = "Av. Uruguay 1330",
                Telefono = "014241522",
                CodigoImagen = "ImgTest01",
                Estrellas = 3
            });

            Assert.AreEqual("HT99999999", nuevaHotel.Codigo);
            Assert.AreEqual("El Reencuentro", nuevaHotel.Nombre);
            Assert.AreEqual("Hotel más caleta de Lima", nuevaHotel.Descripcion);
            Assert.AreEqual("Av. Uruguay 1330", nuevaHotel.Direccion);
            Assert.AreEqual("014241522", nuevaHotel.Telefono);
            Assert.AreEqual("ImgTest01", nuevaHotel.CodigoImagen);
            Assert.AreEqual(3, nuevaHotel.Estrellas);

            EliminarHotelParaPruebas(nuevaHotel.Codigo);
        }

        [TestMethod]
        public void CrearHabitacion_CuandoElCodigoDeHotelYaExiste_RetornaRepetidoException()
        {
            var codigoHotel = "HTXXX00001";
            CrearHotelParaPruebas(codigoHotel);
            HotelesWS.HotelServiceClient proxy = new HotelesWS.HotelServiceClient();

            try
            {
                proxy.CrearHotel(new HotelesWS.Hotels
                {
                    Codigo = codigoHotel,
                    Nombre = "El Reencuentro",
                    Descripcion = "Hotel más caleta de Lima",
                    Direccion = "Av. Uruguay 1330",
                    Telefono = "014241522",
                    CodigoImagen = "ImgTest01",
                    Estrellas = 3
                });
            }
            catch (FaultException<HotelesWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al crear hotel.", error.Reason.ToString());
                Assert.AreEqual("101", error.Detail.Codigo);
                Assert.AreEqual("El hotel con el código ingresado ya existe.", error.Detail.Descripcion);
            }

            EliminarHotelParaPruebas(codigoHotel);
        }

        private static void EliminarHotelParaPruebas(string codigo)
        {
            HotelesWS.HotelServiceClient proxy = new HotelesWS.HotelServiceClient();
            proxy.EliminarHotel(codigo);
        }

        private static HotelesWS.Hotels CrearHotelParaPruebas(string codigoHotel)
        {
            HotelesWS.HotelServiceClient proxy = new HotelesWS.HotelServiceClient();
            return proxy.CrearHotel(new HotelesWS.Hotels
            {
                Codigo = codigoHotel,
                Nombre = "El Reencuentro",
                Descripcion = "Hotel más caleta de Lima",
                Direccion = "Av. Uruguay 1330",
                Telefono = "014241522",
                CodigoImagen = "ImgTest01",
                Estrellas = 3
            });
        }
    }
}