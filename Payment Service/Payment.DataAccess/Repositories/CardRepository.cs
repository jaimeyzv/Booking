using Payment.DataAccess.Dtos.Dtos;
using Payment.DataAccess.Interfaces;
using Payment.DataAccess.Interfaces.IRepositories;
using System;
using System.Collections.Generic;

namespace Payment.DataAccess.Repositories
{
    public class CardRepository : BaseRepository<CardDto>, ICardRepository
    {
        public CardRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<CardDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public CardDto GetByCardNumber(string cardNumber)
        {
            var query = @"SELECT * FROM Card WHERE Number = @0";

            using (var db = dbFactory.GetConnection())
            {
                return db.SingleOrDefault<CardDto>(query, cardNumber);
            }
        }

        public CardDto GetById(int id)
        {
            var query = @"SELECT * FROM Card WHERE CardId = @0";

            using (var db = dbFactory.GetConnection())
            {
                return db.SingleOrDefault<CardDto>(query, id);
            }
        }
    }
}