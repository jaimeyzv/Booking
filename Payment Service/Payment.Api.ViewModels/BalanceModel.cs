namespace Payment.Api.Models
{
    public class BalanceModel
    {
        public int BalanceId { get; set; }
        public decimal Balance { get; set; }
        public int CardId { get; set; }
    }
}