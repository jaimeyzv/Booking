using Payment.DataAccess.Dtos.Dtos;

namespace Payment.DataAccess.Interfaces.IRepositories
{
    public interface IBalanceRepository : IBaseRepository<BalanceDto>
    {
        BalanceDto GetByCreditCardId(int id);
    }
}