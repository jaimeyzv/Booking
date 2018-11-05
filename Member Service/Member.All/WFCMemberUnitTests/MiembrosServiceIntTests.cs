using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
                Assert.AreEqual("Error al crear miembro.", error.Reason.ToString());
                Assert.AreEqual("101", error.Detail.Codigo);
                Assert.AreEqual("El miembro ya existe", error.Detail.Descripcion);
            }
        }

        [TestMethod]
        public void ModificarMiembro_CuandoDniDelMiembroEsExiste_RetornaMiembroModificado()
        {
            var miembroEsperado = new MiembrosWS.Miembro
            {
                Dni = "01012547",
                Nombres = "Anthony",
                ApellidoPaterno = "Astupiña",
                ApellidoMaterno = "Rosillo",
                Edad = 29,
                Activo = false
            };
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            var miembroModificado = proxy.ModificarMiembro(miembroEsperado);

            Assert.AreEqual(miembroEsperado.Dni, miembroModificado.Dni);
            Assert.AreEqual(miembroEsperado.Nombres, miembroModificado.Nombres);
            Assert.AreEqual(miembroEsperado.ApellidoPaterno, miembroModificado.ApellidoPaterno);
            Assert.AreEqual(miembroEsperado.ApellidoMaterno, miembroModificado.ApellidoMaterno);
            Assert.AreEqual(miembroEsperado.Edad, miembroModificado.Edad);
            Assert.AreEqual(miembroEsperado.Activo, miembroModificado.Activo);
        }

        [TestMethod]
        public void ModificarMiembro_CuandoDniDelMiembroNoExiste_RetornaUnErrorConMensajePersonalizado()
        {
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            try
            {
                var nuevoMiembro = proxy.ModificarMiembro(new MiembrosWS.Miembro
                {
                    Dni = "10000001",
                    Nombres = "Anthony",
                    ApellidoPaterno = "Astupiña",
                    ApellidoMaterno = "Rosillo",
                    Edad = 29,
                    Activo = false
                });
            }
            catch (FaultException<MiembrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al modificar miembro.", error.Reason.ToString());
                Assert.AreEqual("103", error.Detail.Codigo);
                Assert.AreEqual("El dni del miembro a modificar no existe.", error.Detail.Descripcion);
            }
        }

        [TestMethod]
        public void EliminarMiembro_CuandoElMiembroNoEstaActivo_EliminaElMiembro()
        {
            var dni = "300xx003";
            CrearMiembroParaPruebas(dni);
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            proxy.EliminarMiembro(dni);
            var miembro = proxy.ObtenerMiembro(dni);

            Assert.IsNull(miembro);
        }

        [TestMethod]
        public void EliminarMiembro_CuandoElMiembroSiEstaActivo_RetornaUnErrorConMensajePersonalizado()
        {
            var dni = "47470738";
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            try
            {
                proxy.EliminarMiembro(dni);
            }
            catch (FaultException<MiembrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al eliminar miembro.", error.Reason.ToString());
                Assert.AreEqual("102", error.Detail.Codigo);
                Assert.AreEqual("No se puede eliminar miember si está activo.", error.Detail.Descripcion);
            }
        }

        [TestMethod]
        public void ObtenerMiembro_CuandoDniDelMiembroEsValido_RetornaElMiembroBuscado()
        {
            var dni = "200ABC03";
            var miembroEsperado = CrearMiembroParaPruebas(dni);
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            proxy.ObtenerMiembro(dni);
            var miembroObtenido = proxy.ObtenerMiembro(dni);

            Assert.AreEqual(miembroEsperado.Dni, miembroObtenido.Dni);
            Assert.AreEqual(miembroEsperado.Nombres, miembroObtenido.Nombres);
            Assert.AreEqual(miembroEsperado.ApellidoPaterno, miembroObtenido.ApellidoPaterno);
            Assert.AreEqual(miembroEsperado.ApellidoMaterno, miembroObtenido.ApellidoMaterno);
            Assert.AreEqual(miembroEsperado.Edad, miembroObtenido.Edad);
            Assert.AreEqual(miembroEsperado.Activo, miembroObtenido.Activo);

            EliminarMiembroParaPruebas(dni);
        }

        [TestMethod]
        public void ObtenerMiembro_CuandoDniDelMiembroEsVacio_RetornaUnErrorConMensajePersonalizado()
        {
            string dni = string.Empty;
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            try
            {
                proxy.ObtenerMiembro(dni);
            }
            catch (FaultException<MiembrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al obtener miembro.", error.Reason.ToString());
                Assert.AreEqual("104", error.Detail.Codigo);
                Assert.AreEqual("El dni ingresado no es válido.", error.Detail.Descripcion);
            }
        }

        [TestMethod]
        public void ObtenerMiembro_CuandoDniDelMiembroEsNulo_RetornaUnErrorConMensajePersonalizado()
        {
            string dni = null;
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            try
            {
                proxy.ObtenerMiembro(dni);
            }
            catch (FaultException<MiembrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al obtener miembro.", error.Reason.ToString());
                Assert.AreEqual("104", error.Detail.Codigo);
                Assert.AreEqual("El dni ingresado no es válido.", error.Detail.Descripcion);
            }
        }

        [TestMethod]
        public void ObtenerMiembro_CuandoDniDelMiembroEsSoloEspacios_RetornaUnErrorConMensajePersonalizado()
        {
            string dni = " ";
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            try
            {
                proxy.ObtenerMiembro(dni);
            }
            catch (FaultException<MiembrosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al obtener miembro.", error.Reason.ToString());
                Assert.AreEqual("104", error.Detail.Codigo);
                Assert.AreEqual("El dni ingresado no es válido.", error.Detail.Descripcion);
            }
        }

        [TestMethod]
        public void ListarMiembros_CuandoHayMiembrosExistentes_RetornaListaDeMiembros()
        {
            string dni1 = "0001ABC1";
            string dni2 = "0001ABC2";
            string dni3 = "0001ABC3";
            var miembroEsperado1 = CrearMiembroParaPruebas(dni1);
            var miembroEsperado2 = CrearMiembroParaPruebas(dni2);
            var miembroEsperado3 = CrearMiembroParaPruebas(dni3);
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();

            var miembros = proxy.ListarMiembros();

            Assert.IsTrue(miembros.Any());
            Assert.IsTrue(miembros.Length >= 3);

            EliminarMiembroParaPruebas(dni1);
            EliminarMiembroParaPruebas(dni2);
            EliminarMiembroParaPruebas(dni3);
        }

        private static MiembrosWS.Miembro CrearMiembroParaPruebas(string dni)
        {
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();
            return proxy.CrearMiembro(new MiembrosWS.Miembro
            {
                Dni = dni,
                Nombres = "Pablo",
                ApellidoPaterno = "Veliz",
                ApellidoMaterno = "Veliz",
                Edad = 31,
                Activo = false
            });
        }
        
        private static void EliminarMiembroParaPruebas(string dni)
        {
            MiembrosWS.MiembrosServiceClient proxy = new MiembrosWS.MiembrosServiceClient();
            proxy.EliminarMiembro(dni);
        }
    }
}