using Payment.Business.Entities;
using Payment.Business.Interfaces;
using Payment.DataAccess.Interfaces.IRepositories;
using Payment.Infrastructure.Interfaces.Mappers;

namespace Payment.Business
{
    public class BalanceBusiness : IBalanceBusiness
    {
        private readonly IBalanceRepository balanceRepository;
        private readonly IMapper mapper;

        public BalanceBusiness(IBalanceRepository balanceRepository, IMapper mapper)
        {
            this.balanceRepository = balanceRepository;
            this.mapper = mapper;

        }

        public BalanceEntity GetBalanceByCardId(int cardId)
        {
            var dto = balanceRepository.GetByCreditCardId(cardId);
            var entity = mapper.MapFromBalanceDtoToBalanceEntity(dto);

            return entity;
        }

        public void UpdateBalance(BalanceEntity entity)
        {
            var dao = mapper.MapFromBalanceEntityToBalanceDto(entity);
            balanceRepository.Update(dao);
        }
    }
}