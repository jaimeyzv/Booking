using Payment.Api.Models;
using Payment.Business.Entities;
using Payment.DataAccess.Dtos.Dtos;
using Payment.Infrastructure.Interfaces.Mappers;

namespace Payment.Infrastructure.Mappers
{
    public class Mapper : IMapper
    {
        public TransactionModel MapFromTransactionFromEntityToModel(TransactionEntity entity)
        {
            return new TransactionModel()
            {
                TransactionCode = entity.TransactionCode,
                TransactionDate = entity.TransactionDate
            };
        }

        public PurchaseEntity MapFromPurchaseFromModelToEntity(PurchaseModel model)
        {
            return new PurchaseEntity() {
                CardNumber = model.CardNumber,
                CardType = model.CardType,
                CardCvv = model.CardCvv,
                CardExpireDate = model.CardExpireDate,
                Cost = model.Cost,
                Description = model.Description
            };
        }

        public CardEntity MapFromCardDtoToCardEntity(CardDto dto)
        {
            return new CardEntity()
            {
                CardId = dto.CardId,
                Name = dto.Name,
                Number = dto.Number,
                ExpireDate = dto.ExpireDate,
                Cvv = dto.Cvv,
                CardTypeId = dto.CardTypeId
            };
        }

        public CardModel MapFromCardEntityToCardModel(CardEntity entity)
        {
            return new CardModel()
            {
                CardId = entity.CardId,
                Name = entity.Name,
                Number = entity.Number,
                ExpireDate = entity.ExpireDate,
                Cvv = entity.Cvv,
                CardTypeId = entity.CardTypeId
            };
        }

        public BalanceEntity MapFromBalanceDtoToBalanceEntity(BalanceDto dto)
        {
            return new BalanceEntity()
            {
                BalanceId = dto.BalanceId,
                Balance = dto.Balance,
                CardId = dto.CardId
            };
        }

        public BalanceModel MapFromBalanceEntityToBalanceModel(BalanceEntity entity)
        {
            return new BalanceModel()
            {
                BalanceId = entity.BalanceId,
                Balance = entity.Balance,
                CardId = entity.CardId
            };
        }

        public BalanceDto MapFromBalanceEntityToBalanceDto(BalanceEntity entity)
        {
            return new BalanceDto()
            {
                BalanceId = entity.BalanceId,
                Balance = entity.Balance,
                CardId = entity.CardId
            };
        }

        public BalanceEntity MapFromBalanceModelToBalanceEntity(BalanceModel model)
        {
            return new BalanceEntity()
            {
                BalanceId = model.BalanceId,
                Balance = model.Balance,
                CardId = model.CardId
            };
        }
    }
}