using Payment.Business.Entities;

namespace Payment.Business.Interfaces
{
    public interface ICardBusiness
    {
        int Create(CardEntity entity);

        void Update(CardEntity entity);

        void Delete(int id);

        CardEntity GetById(int id);

        CardEntity GetByCardNumber(string cardNumber);
    }
}