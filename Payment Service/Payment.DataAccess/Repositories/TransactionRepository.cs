using System.Collections.Generic;
using Payment.DataAccess.Dtos.Dtos;
using Payment.DataAccess.Interfaces;
using Payment.DataAccess.Interfaces.IRepositories;

namespace Payment.DataAccess.Repositories
{
    public class TransactionRepository : BaseRepository<TransactionDto>, ITransactionRepository
    {
        public TransactionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<TransactionDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TransactionDto GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}