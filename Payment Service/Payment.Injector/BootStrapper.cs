using Payment.Business;
using Payment.Business.Interfaces;
using Payment.DataAccess.Interfaces;
using Payment.DataAccess.Interfaces.IRepositories;
using Payment.DataAccess.Repositories;
using Payment.Infrastructure.Interfaces.Mappers;
using Payment.Infrastructure.Interfaces.Services;
using Payment.Infrastructure.Interfaces.Wrappers;
using Payment.Infrastructure.Mappers;
using Payment.Infrastructure.Services;
using Payment.Infrastructure.Wrappers;
using Stamping.DataAccess;
using Stamping.Infrastructure.Wrappers;
using Unity;

namespace Payment.Injector
{
    public class BootStrapper
    {
        public IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();
            RegisterInsfrastructure(container);
            RegisterRepositories(container);
            RegisterBusiness(container);
            SvcLocator.Container = container;

            return container;
        }

        private void RegisterInsfrastructure(UnityContainer container)
        {
            container.RegisterType<IMapper, Mapper>();
            container.RegisterType<IDbFactory, DbFactory>();
            container.RegisterType<IConnectionStringProvider, ConnectionStringProvider>();
            container.RegisterType<IApiResponseWrapper, ApiResponseWrapper>();
            container.RegisterType<IConfigurationManagerWrapper, ConfigurationManagerWrapper>();
        }

        private void RegisterRepositories(UnityContainer container)
        {
            container.RegisterType<IBalanceRepository, BalanceRepository>();
            container.RegisterType<ICardRepository, CardRepository>();
            container.RegisterType<ICardTypeRepository, CardTypeRepository>();
            container.RegisterType<ITransactionRepository, TransactionRepository>();
        }

        private void RegisterBusiness(UnityContainer container)
        {
            container.RegisterType<IPaymentBusiness, PaymentBusiness>();
            container.RegisterType<ICardBusiness, CardBusiness>();
        }
    }
}