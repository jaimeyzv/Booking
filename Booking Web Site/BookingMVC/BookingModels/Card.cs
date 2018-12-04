using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModels
{
    public class Card
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvv { get; set; }
        public int CardTypeId { get; set; }
    }
}