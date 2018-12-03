using Payment.Api.Models;
using Payment.Business.Entities;
using Payment.DataAccess.Dtos.Dtos;
using Payment.Infrastructure.Interfaces.Mappers;

namespace Payment.Infrastructure.Mappers
{
    public class Mapper : IMapper
    {
        public TransactionModel MapTransactionFromEntityToModel(TransactionEntity entity)
        {
            return new TransactionModel()
            {
                TransactionCode = entity.TransactionCode,
                TransactionDate = entity.TransactionDate
            };
        }

        public PurchaseEntity MapPurchaseFromModelToEntity(PurchaseModel model)
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

        public CardEntity MapCardDtoToCardEntity(CardDto dto)
        {
            return new CardEntity()
            {
                CardId = dto.CardId,
                Number = dto.Number,
                ExpireDate = dto.ExpireDate,
                Cvv = dto.Cvv,
                CardTypeId = dto.CardTypeId
            };
        }

        public CardModel MapCardEntityToCardModel(CardEntity entity)
        {
            return new CardModel()
            {
                CardId = entity.CardId,
                Number = entity.Number,
                ExpireDate = entity.ExpireDate,
                Cvv = entity.Cvv,
                CardTypeId = entity.CardTypeId
            };
        }
    }
}