using System.Runtime.Serialization;

namespace MobilityService.Dominio
{
    [DataContract]
    public class Movilidad
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int tipoMovilidad { get; set; }
        [DataMember]
        public int numeroPasajeros { get; set; }
        [DataMember]
        public decimal costoPorTramo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public bool disponibilidad { get; set; }

    }
}