using System.Runtime.Serialization;

namespace WCFMember.Errores
{
    [DataContract]
    [KnownType(typeof(RepetidoException))]
    public class RepetidoException
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}