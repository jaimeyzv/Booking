using Payment.Business.Entities;
using Payment.Business.Interfaces;
using Payment.DataAccess.Interfaces.IRepositories;
using Payment.Infrastructure.Interfaces.Mappers;
using System;

namespace Payment.Business
{
    public class CardBusiness : ICardBusiness
    {
        private readonly ICardRepository cardRepository;
        private readonly IMapper mapper;

        public CardBusiness(ICardRepository cardRepository, IMapper mapper)
        {
            this.cardRepository = cardRepository;
            this.mapper = mapper;

        }

        public int Create(CardEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CardEntity GetByCardNumber(string cardNumber)
        {
            var card = cardRepository.GetByCardNumber(cardNumber);
            var cardEntity = mapper.MapFromCardDtoToCardEntity(card);

            return cardEntity;
        }

        public CardEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CardEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}