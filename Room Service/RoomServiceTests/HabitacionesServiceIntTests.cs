using System;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoomServiceTests
{
    /// <summary>
    /// Descripción resumida de HabitacionesServiceIntTests
    /// </summary>
    [TestClass]
    public class HabitacionesServiceIntTests
    {
        [TestMethod]
        public void CrearHabitacion_CuandoNuevaHabitacionEsValida_RetornaNuevaHabitacionCreada()
        {
            Random random = new Random();
            var numero = random.Next(1, 999999);
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();

            var nuevaHabitacion = proxy.CrearHabitacion(new HabitacionesWS.Habitacion
            {
                numero = numero,
                camas = 2,
                descripcion = "habitación de prueba",
                disponibilidad = true
            });

            Assert.AreEqual(numero, nuevaHabitacion.numero);
            Assert.AreEqual(2, nuevaHabitacion.camas);
            Assert.AreEqual("habitación de prueba", nuevaHabitacion.descripcion);
            Assert.AreEqual(true, nuevaHabitacion.disponibilidad);
        }

        [TestMethod]
        public void CrearHabitacion_CuandoNuevaHabitacionNoEsValida_RetornaUnErrorConMensajePersonalizado()
        {
            HabitacionesWS.HabitacionesServiceClient proxy = new HabitacionesWS.HabitacionesServiceClient();

            try
            {
                var nuevaHabitacion = proxy.CrearHabitacion(new HabitacionesWS.Habitacion
                {
                    numero = 666,
                    camas = 2,
                    descripcion = "habitación de prueba",
                    disponibilidad = true
                });
            }
            catch (FaultException<HabitacionesWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al crear habitación", error.Reason.ToString());
                Assert.AreEqual("101", error.Detail.Codigo);
                Assert.AreEqual("La habitación ya existe", error.Detail.Descripcion);
            }
        }
    }
}
