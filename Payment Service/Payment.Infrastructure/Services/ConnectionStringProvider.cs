using Payment.Infrastructure.Interfaces.Services;
using Payment.Infrastructure.Interfaces.Wrappers;
using System;

namespace Payment.Infrastructure.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfigurationManagerWrapper _configurationManagerWrapper;

        public ConnectionStringProvider(IConfigurationManagerWrapper configurationManagerWrapper)
        {
            _configurationManagerWrapper = configurationManagerWrapper;
        }
        public string GetConnectionString()
        {
            return _configurationManagerWrapper.GetAppSettings("StampingDB", string.Empty);
        }

        public void SetConnectionString(string connectionString)
        {
            throw new NotImplementedException();
        }

        public string GetShopVisibleConnectionString()
        {
            return
                _configurationManagerWrapper.GetConnectionString("ShopVisible.Core.DataLayer.Properties.Settings.ShopVisibleConnectionString");
        }
    }
}