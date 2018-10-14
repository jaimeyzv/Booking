using Payment.DataAccess.Dtos;
using Payment.DataAccess.Interfaces;
using Payment.DataAccess.Interfaces.IRepositories;
using System.Collections.Generic;

namespace Payment.DataAccess.Repositories
{
    public class CardTypeRepository : BaseRepository<CardTypeDto>, ICardTypeRepository
    {
        public CardTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<CardTypeDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public CardTypeDto GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}