using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCFMemberTests.MiembrosWS
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Random random = new Random();
            var dni = random.Next(10000000, 99999999).ToString();

            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();
            var nuevoMiembro = proxy.CrearMiembro(new MiembrosWS.Miembro
            {
                Dni = dni,
                Nombres = "Juan Jose",
                ApellidoPaterno = "Vento",
                ApellidoMaterno = "Sevilla",
                Edad = 30,
                Activo = true
            });

            Assert.AreEqual(dni, nuevoMiembro.Dni);
            Assert.AreEqual("Juan Jose", nuevoMiembro.Nombres);
            Assert.AreEqual("Vento", nuevoMiembro.ApellidoPaterno);
            Assert.AreEqual("Sevilla", nuevoMiembro.ApellidoMaterno);
            Assert.AreEqual(30, nuevoMiembro.Edad);
            Assert.AreEqual(true, nuevoMiembro.Activo);
        }
    }
}