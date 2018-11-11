using System;

namespace Payment.Api.Models
{
    public class PurchaseModel
    {
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardCvv { get; set; }
        public DateTime CardExpireDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}