using NPoco;

namespace Payment.DataAccess.Dtos
{
    [TableName("CardType")]
    [PrimaryKey("CardTypeId")]
    public class CardTypeDto
    {
        public int CardTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}