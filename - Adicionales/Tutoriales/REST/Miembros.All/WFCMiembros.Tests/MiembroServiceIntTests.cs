using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using WFCMiembros.Dominio;
using WFCMiembros.Errores;

namespace WFCMiembros.Tests
{
    [TestClass]
    public class MiembroServiceIntTests
    {
        [TestMethod]
        public void CrearMiembro_CuandoDniNoEstaRegistrado_RetornaNuevoMiembroCreado()
        {
            var miembro = new Miembro()
            {
                Nombres = "José José",
                ApellidoPaterno = "García",
                ApellidoMaterno = "Materno",
                Dni = "20202020",
                Correo = "jose.jose@gmail.com",
                Edad = 25,
                Password = "ABC123456abc"
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postData = js.Serialize(miembro);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12326/MiembroServices.svc/Miembros");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            Miembro miembroCreado = js.Deserialize<Miembro>(tramaJson);

            Assert.AreEqual(miembro.Nombres, miembroCreado.Nombres);
            Assert.AreEqual(miembro.ApellidoPaterno, miembroCreado.ApellidoPaterno);
            Assert.AreEqual(miembro.ApellidoMaterno, miembroCreado.ApellidoMaterno);
            Assert.AreEqual(miembro.Dni, miembroCreado.Dni);
            Assert.AreEqual(miembro.Edad, miembroCreado.Edad);
            Assert.AreEqual(miembro.Correo, miembroCreado.Correo);
            Assert.IsTrue(miembroCreado.MiembroId != 0);
            Assert.IsTrue(miembroCreado.Activo);
        }

        [TestMethod]
        public void CrearMiembro_CuandoDniEstaRegistrado_RetornaDuplicadoException()
        {
            var miembro = new Miembro()
            {
                Nombres = "José José",
                ApellidoPaterno = "García",
                ApellidoMaterno = "Materno",
                Dni = "47470738",
                Correo = "jose.jose@gmail.com",
                Edad = 25,
                Password = "ABC123456abc"
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postData = js.Serialize(miembro);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12326/MiembroServices.svc/Miembros");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = null;

            try
            {
                response  = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                HttpStatusCode codigo = ((HttpWebResponse)ex.Response).StatusCode;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                NoExisteException noExisteException = js.Deserialize<NoExisteException>(tramaJson);

                Assert.AreEqual("Conflict", codigo.ToString());
                Assert.AreEqual("103", noExisteException.Codigo);
                Assert.AreEqual("Ya existe miembro con el dni ingresado: 47470738", noExisteException.Descripcion);
            }
        }

        [TestMethod]
        public void ObtenerMiembro_CuandoDniEstaRegistrado_RetornaMiembro()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12326/MiembroServices.svc/Miembros/47470738");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            Miembro miembroCreado = js.Deserialize<Miembro>(tramaJson);

            Assert.AreEqual("Jaime Yampiere", miembroCreado.Nombres);
            Assert.AreEqual("Zamora", miembroCreado.ApellidoPaterno);
            Assert.AreEqual("Vasquez", miembroCreado.ApellidoMaterno);
            Assert.AreEqual("47470738", miembroCreado.Dni);
            Assert.AreEqual(27, miembroCreado.Edad);
            Assert.AreEqual("jyzamorav@gmail.com", miembroCreado.Correo);
        }

        [TestMethod]
        public void ObtenerMiembro_CuandoDniNoEstaRegistrado_RetornaNoExisteException()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:12326/MiembroServices.svc/Miembros/00000014");
            request.Method = "GET";
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                HttpStatusCode codigo = ((HttpWebResponse)ex.Response).StatusCode;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                NoExisteException noExisteException = js.Deserialize<NoExisteException>(tramaJson);

                Assert.AreEqual("Conflict", codigo.ToString());
                Assert.AreEqual("101", noExisteException.Codigo);
                Assert.AreEqual("No existe miembro con el dni ingresado: 00000014", noExisteException.Descripcion);
            }
        }
    }
}