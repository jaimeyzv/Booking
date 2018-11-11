using NPoco;
using System;

namespace Payment.DataAccess.Dtos.Dtos
{
    [TableName("Transaction")]
    [PrimaryKey("TransactionId")]
    public class TransactionDto
    {
        public string TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal FinalBalance { get; set; }
        public int CardId { get; set; }
    }
}