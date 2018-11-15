using System.Runtime.Serialization;

namespace WcfHotel.Dominio
{

    [DataContract]
    public class Hotels
    {
        [DataMember]
        public int HotelId { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public int Estrellas { get; set; }
        [DataMember]
        public bool Activo { get; set; }
    }
}