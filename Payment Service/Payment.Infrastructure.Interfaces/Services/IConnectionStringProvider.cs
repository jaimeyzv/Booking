namespace Payment.Infrastructure.Interfaces.Services
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
        void SetConnectionString(string connectionString);
    }
}