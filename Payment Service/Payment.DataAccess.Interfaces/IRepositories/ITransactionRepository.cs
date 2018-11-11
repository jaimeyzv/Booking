using Payment.DataAccess.Dtos.Dtos;

namespace Payment.DataAccess.Interfaces.IRepositories
{
    public interface ITransactionRepository : IBaseRepository<TransactionDto>
    {
    }
}