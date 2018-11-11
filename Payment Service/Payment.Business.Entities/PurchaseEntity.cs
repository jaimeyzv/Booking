using System;

namespace Payment.Business.Entities
{
    public class PurchaseEntity
    {
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardCvv { get; set; }
        public DateTime CardExpireDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}