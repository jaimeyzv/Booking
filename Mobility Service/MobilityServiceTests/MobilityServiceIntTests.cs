using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilityService.Dominio;
using MobilityService.Errores;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace MobilityServiceTests
{
    [TestClass]
    public class MobilityServiceIntTests
    {
        [TestMethod]
        public void CrearMovilidad_CodigoNoCreado_RetornaNuevaMovilidad()
        {
            var movilidad = new Movilidad()
            {
                codigo = 666,
                tipoMovilidad = 1,
                numeroPasajeros = 15,
                costoPorTramo = 45.50m,
                descripcion = "Moderna van para 15 ocupantes. Cuenta con aire acondicionado y sistema de audio profesional.",
                disponibilidad = true
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postData = js.Serialize(movilidad);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:65074/MobilityServices.svc/Movilidades");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            Movilidad movilidadCreada = js.Deserialize<Movilidad>(tramaJson);

            Assert.AreEqual(movilidad.codigo, movilidadCreada.codigo);
            Assert.AreEqual(movilidad.tipoMovilidad, movilidadCreada.tipoMovilidad);
            Assert.AreEqual(movilidad.numeroPasajeros, movilidadCreada.numeroPasajeros);
            Assert.AreEqual(movilidad.costoPorTramo, movilidadCreada.costoPorTramo);
            Assert.AreEqual(movilidad.descripcion, movilidadCreada.descripcion);
            Assert.IsTrue(movilidadCreada.id != 0);
            Assert.IsTrue(movilidadCreada.disponibilidad);
        }

        [TestMethod]
        public void CrearMovilidad_CodigoCreado_RetornaDuplicadoException()
        {
            var movilidad = new Movilidad()
            {
                codigo = 123,
                tipoMovilidad = 1,
                numeroPasajeros = 10,
                costoPorTramo = 10.99m,
                descripcion = "Movilidad de prueba",
                disponibilidad = true
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string postData = js.Serialize(movilidad);
            byte[] data = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:65074/MobilityServices.svc/Movilidades");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";

            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = null;

            try
            { response = (HttpWebResponse)request.GetResponse(); }
            catch(WebException ex)
            {
                HttpStatusCode codigo = ((HttpWebResponse)ex.Response).StatusCode;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                NoExisteException noExisteException = js.Deserialize<NoExisteException>(tramaJson);

                Assert.AreEqual("Conflict", codigo.ToString());
                Assert.AreEqual("102", noExisteException.Codigo);
                Assert.AreEqual("Ya existe movilidad con el código ingresado: 123", noExisteException.Descripcion);
            }
        }

        [TestMethod]
        public void ObtenerMovilidad_CodigoCreado_RetornaMovilidad()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:65074/MobilityServices.svc/Movilidades/123");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            Movilidad movilidadCreada = js.Deserialize<Movilidad>(tramaJson);

            Assert.AreEqual(123, movilidadCreada.codigo);
            Assert.AreEqual(1, movilidadCreada.tipoMovilidad);
            Assert.AreEqual(10, movilidadCreada.numeroPasajeros);
            Assert.AreEqual(10.99m, movilidadCreada.costoPorTramo);
            Assert.AreEqual("Movilidad de prueba", movilidadCreada.descripcion);
        }

        [TestMethod]
        public void ObtenerMovilidad_CodigoNoCreado_RetornaNoExisteException()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:65074/MobilityServices.svc/Movilidades/666666");
            request.Method = "GET";
            HttpWebResponse response = null;

            try
            { response = (HttpWebResponse)request.GetResponse(); }
            catch (WebException ex)
            {
                HttpStatusCode codigo = ((HttpWebResponse)ex.Response).StatusCode;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                NoExisteException noExisteException = js.Deserialize<NoExisteException>(tramaJson);

                Assert.AreEqual("Conflict", codigo.ToString());
                Assert.AreEqual("101", noExisteException.Codigo);
                Assert.AreEqual("No existe movilidad con el código ingresado: 666666", noExisteException.Descripcion);
            }
        }
    }
}
