using System.Runtime.Serialization;

namespace MobilityService.Errores
{
    [DataContract]
    public class DuplicadoException
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}