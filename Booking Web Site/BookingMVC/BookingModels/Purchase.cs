using System;

namespace BookingModels
{
    public class Purchase
    {
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CardCvv { get; set; }
        public DateTime CardExpireDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}