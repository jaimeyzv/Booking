using System;

namespace Payment.Api.Models
{
    public class TransactionModel
    {
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}