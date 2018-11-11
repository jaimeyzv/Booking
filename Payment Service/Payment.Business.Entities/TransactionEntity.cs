using System;

namespace Payment.Business.Entities
{
    public class TransactionEntity
    {
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}