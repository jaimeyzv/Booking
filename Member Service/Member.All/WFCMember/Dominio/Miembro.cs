using System.Runtime.Serialization;

namespace WCFMember.Dominio
{
    [DataContract]
    public class Miembro
    {
        [DataMember]
        public int MiembroId { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public int Edad { get; set; }
        [DataMember]
        public bool Activo { get; set; }
    }
}