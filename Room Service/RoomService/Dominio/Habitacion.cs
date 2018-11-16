using System.Runtime.Serialization;

namespace RoomService.Dominio
{
    [DataContract]
    public class Habitacion
    {
        [DataMember]
        public int HabitacionId { get; set; }
        [DataMember]
        public string CodigoHabitacion { get; set; }
        [DataMember]
        public string CodigoHotel { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public int CantidadCamas { get; set; }
        [DataMember]
        public bool Disponible { get; set; }
    }
}