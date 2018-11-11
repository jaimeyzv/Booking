using Payment.DataAccess.Dtos.Dtos;
using Payment.DataAccess.Interfaces;
using Payment.DataAccess.Interfaces.IRepositories;
using System;
using System.Collections.Generic;

namespace Payment.DataAccess.Repositories
{
    public class BalanceRepository : BaseRepository<BalanceDto>, IBalanceRepository
    {
        public BalanceRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<BalanceDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public BalanceDto GetByCreditCardId(int id)
        {
            var query = @"SELECT * FROM Balance WHERE CardId = @0";

            using (var db = dbFactory.GetConnection())
            {
                return db.SingleOrDefault<BalanceDto>(query, id);
            }
        }

        public BalanceDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}