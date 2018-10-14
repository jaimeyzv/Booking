using NPoco;

namespace Payment.DataAccess.Interfaces
{
    public interface IDbFactory
    {
        IDatabase GetConnection();
    }
}