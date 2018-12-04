using Payment.Business.Entities;

namespace Payment.Business.Interfaces
{
    public interface IBalanceBusiness
    {
        BalanceEntity GetBalanceByCardId(int cardId);
        void UpdateBalance(BalanceEntity entity);
    }
}