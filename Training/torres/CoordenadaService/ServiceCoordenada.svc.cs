using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CoordenadaService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCoordenada" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceCoordenada.svc o ServiceCoordenada.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceCoordenada : IServiceCoordenada
    {
        public object Coordenada()
        {
            Random rdn = new Random();
            object coor = "Latitud " + rdn.Next(-90, 90) + " ° . " + rdn.Next(0, 60) + " m. " + rdn.Next(0, 60) + "s" + 
            " Longitud "+ rdn.Next(-180, 180) + " ° . " + rdn.Next(0, 60) + " m. " + rdn.Next(0, 60) + "s";
           

            return coor;
         //   return string.Concat(latitude);

        }

       
 //       public string Concat()
  //      {
    //        object var1;
      //      var1 = Coordenada();
        //    return string.Concat(var1);

        //}
    }
}
