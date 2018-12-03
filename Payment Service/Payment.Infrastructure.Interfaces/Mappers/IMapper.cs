using Payment.Api.Models;
using Payment.Business.Entities;
using Payment.DataAccess.Dtos.Dtos;

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

        #region Card

        CardEntity MapCardDtoToCardEntity(CardDto dto);
        CardModel MapCardEntityToCardModel(CardEntity entity);

        #endregion
    }
}