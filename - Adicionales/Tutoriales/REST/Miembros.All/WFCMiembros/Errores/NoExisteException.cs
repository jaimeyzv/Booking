using System.Runtime.Serialization;

namespace WFCMiembros.Errores
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