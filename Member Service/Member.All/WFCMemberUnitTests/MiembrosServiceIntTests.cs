using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

namespace WCFMemberTests
{
    [TestClass]
    public class MiembrosServiceIntTests
    {
        [TestMethod]
        public void CrearMiembro_CuandoNuevoMiembroEsValido_RetornaNuevoMiembroCreado()
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

        [TestMethod]
        public void CrearMiembro_CuandoNuevoMiembroNoEsValido_RetornaUnErrorConMensajePersonalizado()
        {
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            try
            {
                var nuevoMiembro = proxy.CrearMiembro(new MiembrosWS.Miembro
                {
                    Dni = "47470738",
                    Nombres = "Juan Jose",
                    ApellidoPaterno = "Vento",
                    ApellidoMaterno = "Sevilla",
                    Edad = 30,
                    Activo = true
                });
            }
            catch (FaultException<MiembrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al crear miembro", error.Reason.ToString());
                Assert.AreEqual("101", error.Detail.Codigo);
                Assert.AreEqual("El miembro ya existe", error.Detail.Descripcion);
            }
        }
    }
}