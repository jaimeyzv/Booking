using Payment.Api.Models;
using Payment.Business.Entities;
using Payment.DataAccess.Dtos.Dtos;

namespace Payment.Infrastructure.Interfaces.Mappers
{
    public interface IMapper
    {
        #region Purchase

        PurchaseEntity MapFromPurchaseFromModelToEntity(PurchaseModel model);

        #endregion

        #region Transaction

        TransactionModel MapFromTransactionFromEntityToModel(TransactionEntity entity);

        #endregion

        #region Card

        CardEntity MapFromCardDtoToCardEntity(CardDto dto);
        CardModel MapFromCardEntityToCardModel(CardEntity entity);

        #endregion

        #region Balance

        BalanceEntity MapFromBalanceDtoToBalanceEntity(BalanceDto dto);
        BalanceModel MapFromBalanceEntityToBalanceModel(BalanceEntity entity);
        BalanceDto MapFromBalanceEntityToBalanceDto(BalanceEntity entity);
        BalanceEntity MapFromBalanceModelToBalanceEntity(BalanceModel model);

        #endregion
    }
}