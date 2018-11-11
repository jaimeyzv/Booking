using System;

namespace Payment.Api.Models
{
    public class TransactionModel
    {
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}