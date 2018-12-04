namespace Payment.Business.Entities
{
    public class BalanceEntity
    {
        public int BalanceId { get; set; }
        public decimal Balance { get; set; }
        public int CardId { get; set; }
    }
}