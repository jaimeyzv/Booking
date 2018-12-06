using BookingModels;
using RestSharp;

namespace Booking.DataAccess
{
    public class CardApi
    {
        public Card ObtenerPorNumerTarjeta(string numero)
        {
            var client = new RestClient("http://localhost:9609/");
            var request = new RestRequest("api/card/{cardNumber}", Method.GET);
            request.AddParameter("cardNumber", numero);
            var queryResult = client.Execute<Card>(request).Data;
            
            return queryResult;
        }
    }
}