using NPoco;

namespace Payment.DataAccess.Dtos.Dtos
{
    [TableName("Balance")]
    [PrimaryKey("BalanceId")]
    public class BalanceDto
    {
        public int BalanceId { get; set; }
        public decimal Balance { get; set; }
        public int CardId { get; set; }
    }
}
