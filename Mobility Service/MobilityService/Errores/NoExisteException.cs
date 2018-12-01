using System.Runtime.Serialization;

namespace MobilityService.Errores
{
    [DataContract]
    public class NoExisteException
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}