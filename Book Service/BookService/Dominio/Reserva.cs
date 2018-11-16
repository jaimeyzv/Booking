using System;
using System.Runtime.Serialization;

namespace BookService.Dominio
{
    [DataContract]
    public class Reserva
    {
        [DataMember]
        public int ReservaId { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string DniMiembro { get; set; }
        [DataMember]
        public string CodigoHotel { get; set; }
        [DataMember]
        public string CodigoHabitacion { get; set; }
        [DataMember]
        public int NumeroHabitacion { get; set; }
        [DataMember]
        public decimal PrecioHotel { get; set; }
        [DataMember]
        public int CantidadPersonas { get; set; }
        [DataMember]
        public DateTime FechaCheckIn { get; set; }
        [DataMember]
        public DateTime FechaCheckOut { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}