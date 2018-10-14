using NPoco;
using System;

namespace Payment.DataAccess.Dtos.Dtos
{
    [TableName("Card")]
    [PrimaryKey("CardId")]
    public class CardDto
    {
        public int CardId { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvv { get; set; }
        public int CardTypeId { get; set; }
    }
}