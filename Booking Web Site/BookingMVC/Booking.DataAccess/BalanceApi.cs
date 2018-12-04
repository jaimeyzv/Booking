using BookingModels;
using RestSharp;

namespace Booking.DataAccess
{
    public class BalanceApi
    {
        public Balances ObtenerSaldoPorCardId(int cardId)
        {
            var client = new RestClient("http://localhost:91/");
            var request = new RestRequest("api/balance/{cardId}", Method.GET);
            request.AddParameter("cardId", cardId);
            var queryResult = client.Execute<Balances>(request).Data;

            return queryResult;
        }
    }
}