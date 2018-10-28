using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSClima
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ClimasService : IClimasService
    {
        public string ConsultarClima(int zip)
        {
            String ciudad;
            switch(zip)
            {
                case 1:
                    ciudad = "Lima";
                    break;
                case 2:
                    ciudad = "Arequipa";
                    break;
                case 3:
                    ciudad = "Trujillo";
                    break;
                default:
                    ciudad = "Moquegua";
                    break;
            }
            return string.Format("La temperatura en " + ciudad + " es de " + obtenerTemperatura() + " grados");
        }

        public int obtenerTemperatura()
        {
            
            //TempWS.TemperaturaServiceClient proxy = new TempWS.TemperaturaServiceClient();
            //return proxy.ObtenerTemperatura();
            return 1;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
