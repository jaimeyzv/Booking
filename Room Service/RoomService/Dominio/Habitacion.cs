using System.Runtime.Serialization;

namespace RoomService.Dominio
{
    [DataContract]
    public class Habitacion
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int numero { get; set; }
        [DataMember]
        public int camas { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public bool disponibilidad { get; set; }
    }
}