using System.ServiceModel;

namespace BookService
{
    [ServiceContract]
    public interface IReservaService
    {
        [OperationContract]
        void DoWork();
    }
}