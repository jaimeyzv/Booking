using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfHotel.Dominio
{

    [DataContract]
    public class Hotel
    {
        [DataMember]
        public int IdHotel { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        public string Telefono { get; set; }
    }
}