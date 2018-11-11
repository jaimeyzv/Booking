using Payment.Api.Models;
using Payment.Business.Entities;

namespace Payment.Infrastructure.Interfaces.Mappers
{
    public interface IMapper
    {
        #region Purchase

        PurchaseEntity MapPurchaseFromModelToEntity(PurchaseModel model);

        #endregion

        #region Transaction

        TransactionModel MapTransactionFromEntityToModel(TransactionEntity entity);

        #endregion
    }
}