using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BookService.Dominio
{
    [DataContract]
    public class Reserva
    {
        [DataMember]
        public int IdReserva { get; set; }

        [DataMember]
        public int NuHabitacion { get; set; }

        [DataMember]
        public int NuPasajeros { get; set; }

        [DataMember]
        public string TipoHabitacion { get; set; }

        [DataMember]
        public decimal PrecioHabitacion { get; set; }

        [DataMember]
        public DateTime FechaReservaIn { get; set; }

        [DataMember]
        public DateTime FechaReservaOut { get; set; }

        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}