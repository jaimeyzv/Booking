using System;

namespace Payment.Business.Entities
{
    public class CardEntity
    {
        public int CardId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvv { get; set; }
        public int CardTypeId { get; set; }
    }
}