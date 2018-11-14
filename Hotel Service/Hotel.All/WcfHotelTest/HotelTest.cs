using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace WcfHotelTest
{


    [TestClass]
    public class HotelTest
    {

        [TestMethod]
        public void Test1CrearHotelOk()
        {
            HotelWS.HotelServiceClient proxy = new HotelWS.HotelServiceClient();
            HotelWS.Hotel hotelcreado = proxy.CrearHotel(new HotelWS.Hotel()
            {

                Nombre = "Skorpio",
                Direccion = "Nicolas de pierola",
                Telefono = "1234568"
            });

            Assert.AreEqual("Skorpio", hotelcreado.Nombre);
            Assert.AreEqual("Nicolas de pierola", hotelcreado.Direccion);
            Assert.AreEqual("1234568", hotelcreado.Telefono);

        }


        [TestMethod]
        public void Test2CrearHotelRepetido()
        {
            HotelWS.HotelServiceClient proxy = new HotelWS.HotelServiceClient();
            try
            {
                HotelWS.Hotel hotelcreado = proxy.CrearHotel(new HotelWS.Hotel()
                {
                    IdHotel = 0,
                    Nombre = "SHERATON",
                    Direccion = "AV. LAS FLORES",
                    Telefono = "1234567"
                });
            }
            catch (FaultException<HotelWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al crear hotel", error.Reason.ToString());
                Assert.AreEqual("101", error.Detail.Codigo);
                Assert.AreEqual("El hotel ya existe", error.Detail.Descripcion);
            }
        }


        [TestMethod]
        public void Test1ModificarHotelOk()
        {

            HotelWS.Hotel hotelEsperado =new HotelWS.Hotel
           
            {
                IdHotel = 0,
                Nombre = "Skorpio",
                Direccion = "Nicolas de pierola",
                Telefono = "1234568"
            };

            HotelWS.HotelServiceClient proxy = new HotelWS.HotelServiceClient();
            HotelWS.Hotel hotelmodificado = proxy.ModificarHotel(hotelEsperado);


            Assert.AreEqual(hotelEsperado.Nombre, hotelmodificado.Nombre);
            Assert.AreEqual(hotelEsperado.Direccion,hotelmodificado.Direccion);
            Assert.AreEqual(hotelEsperado.Telefono,hotelmodificado.Telefono);

        }


        [TestMethod]

        public void Test2ModificarHotelRepetido()
        {
            HotelWS.HotelServiceClient proxy = new HotelWS.HotelServiceClient();
            try
            {
                HotelWS.Hotel nuevohotel = proxy.ModificarHotel(new HotelWS.Hotel
                {
                    IdHotel = 0,
                    Nombre = "SHERATON",
                    Direccion = "AV. LAS FLORES",
                    Telefono = "1234567"
                });
            }
            catch (FaultException<HotelWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al modificar hotel", error.Reason.ToString());
                Assert.AreEqual("102", error.Detail.Codigo);
                Assert.AreEqual("El hotel a modificar no existe", error.Detail.Descripcion);
            }
        }



        [TestMethod]
        private static HotelWS.Hotel CrearHotelParaPruebas(int idHotel)
        {
            HotelWS.HotelServiceClient proxy = new HotelWS.HotelServiceClient();
            return proxy.CrearHotel(new HotelWS.Hotel
            {
                IdHotel = idHotel,
                Nombre = "Skorpio",
                Direccion = "Nicolas de pierola",
                Telefono = "1234568"
            });
        }

        [TestMethod]
        private static void EliminarMiembroParaPruebas(int idHotel)
        {
            HotelWS.HotelServiceClient proxy = new HotelWS.HotelServiceClient();
            proxy.EliminarHotel(idHotel);
        }

    }
}
