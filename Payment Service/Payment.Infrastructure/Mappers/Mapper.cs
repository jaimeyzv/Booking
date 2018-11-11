using Payment.Api.Models;
using Payment.Business.Entities;
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
    }
}