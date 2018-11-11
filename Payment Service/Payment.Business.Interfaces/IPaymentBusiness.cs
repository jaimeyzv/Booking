using Payment.Business.Entities;

namespace Payment.Business.Interfaces
{
    public interface IPaymentBusiness
    {
        TransactionEntity Pay(PurchaseEntity entity);
    }
}